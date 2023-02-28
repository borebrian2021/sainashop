using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lubes.DBContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SHOP_DECOMPILED;
using SHOP_DECOMPILED.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SHOP_DECOMPILED.Controllers
{
    [Authorize]
    public class Calculations : Controller
    {
        private readonly ApplicationDBContext _context;

        public Calculations(ApplicationDBContext context)
        {
            _context = context;
        }
        
        private static TimeZoneInfo E_Africa_standard_time = TimeZoneInfo.FindSystemTimeZoneById("E. Africa Standard Time");
        private static DateTime today1 = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, E_Africa_standard_time);
        string today = today1.ToString("dd/MM/yyyy");
        string time_stamp = today1.ToString("dd/MM/yyyy/hh:mm:ss");

        internal void station_name(int station_id)
        {
            ViewBag.station_name = _context.Fuel_station_reg.FirstOrDefault(x => x.id == station_id).Station_Name;

        }

        // GET: System_users
        public class response
        {

            public string response_msg { get; set; }
        }
        [HttpPost]

        public JsonResult refill_fuel(int id,double Ammount_refilled, double initial_readings,double final_readings,double agent_id)
        {
            response r = new response();

            try
            {
                //UPDATE TANK
                var t = _context.Fuel_category.FirstOrDefault(x => x.id == id);
                t.Current_quantity = final_readings;
                _context.Entry(t).State = EntityState.Modified;
                _context.SaveChanges();

                //KEEP HISTORY
                Refill_history x = new Refill_history();

                x.agent_id = 1;
                x.Ammount_refilled = Ammount_refilled;
                x.Date_refilled = today;
                x.final_readings = final_readings;
                x.Fuel_id=id;
                x.initial_readings = initial_readings;
                _context.Add(x);
                _context.SaveChanges();

                var sms_settings = _context.SMS_Settings.FirstOrDefault(z => z.Fuel_id == id.ToString()).status;

                if (sms_settings == "On")
                {

                    //SEND MESSAGE

                    var admin_name = _context.System_users.FirstOrDefault(z => z.Roles == 1).Full_name;
                    var fuel = _context.Fuel_category.FirstOrDefault(z => z.id == id);
                    var station = _context.Fuel_station_reg.FirstOrDefault(x => x.id == fuel.Station_id);

                    SendMessage("Hallo " + admin_name + " You are notified that : " + fuel.Fuel_names + ", has been refilled from: " + initial_readings + "to :" + final_readings + ". at " + time_stamp + ". Thank you!");

                }

                r.response_msg = "Ok";
                return Json(r);

            }
            catch (Exception x)
            {

                r.response_msg = x.ToString();
                return Json(r);

            }
        } 
        
        [HttpPost]

        public JsonResult change_pricsene(int id, double new_price)
        {
            response r = new response();

            try
            {
                var toedit = _context.Fuel_category.FirstOrDefault(x => x.id == id);
                var o_price = toedit.Price;
                toedit.Price = new_price;
                _context.Entry(toedit).State = EntityState.Modified;
                _context.SaveChanges();

                var sms_settings = _context.SMS_Settings.FirstOrDefault(z => z.Fuel_id == id.ToString()).status;

                if (sms_settings == "On")
                {

                    //SEND MESSAGE

                    var admin_name = _context.System_users.FirstOrDefault(z => z.Roles == 1).Full_name;
                    var fuel = _context.Fuel_category.FirstOrDefault(z => z.id == id);
                    var station = _context.Fuel_station_reg.FirstOrDefault(x => x.id == fuel.Station_id);

                    SendMessage("Hallo " + admin_name + " You are notified that there was a price change of : " + fuel.Fuel_names + ", from: " + o_price + "to :" + new_price + ". at " + time_stamp + ". Thank you!");

                }

                r.response_msg = "Ok";
                return Json(r);

            }
            catch (Exception x)
            {

                r.response_msg = x.ToString();
                return Json(r);

            }
        }
            [HttpPost]
            

        public JsonResult  Submit_fuel_sales(double c_meter,double p_meter,double calculated,double sold,int f_id,double total,double price,int m_id)
        {
            response r = new response();
           

            //UPDATE FUEL
            var update_tank = _context.Fuel_category.FirstOrDefault(x => x.id == f_id);
            double initial_tank = update_tank.Current_quantity;
            double new_tank = initial_tank - sold;
            if (new_tank < 0)
            {
                r.response_msg = "failure";
                return Json(r);

            }
            else
            {
                update_tank.Current_quantity = new_tank;
                _context.Entry(update_tank).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                var sms_settings = _context.SMS_Settings.FirstOrDefault(z => z.Fuel_id == f_id.ToString()).status;

                if (sms_settings=="On")
                {

                    //SEND MESSAGE
                    var sms_level = _context.SMS_Settings.FirstOrDefault(z => z.Fuel_id == f_id.ToString()).Level;
                    var admin_name = _context.System_users.FirstOrDefault(z => z.Roles == 1).Full_name;
                    var fuel = _context.Fuel_category.FirstOrDefault(z => z.id == f_id);
                    var station = _context.Fuel_station_reg.FirstOrDefault(x => x.id == fuel.Station_id);
                    if (new_tank < sms_level)
                    {
                        SendMessage("Hallo " + admin_name + " You are notified to refill fuel at: " + station.Station_Name + ",Fuel category: " + fuel.Fuel_names + ", Fuel left: " + fuel.Current_quantity + ". You can disable this notification in your fuel management system.Thank you!.");
                    }
                }
                //UPDATE METER READINGS
                var to_update = _context.Meter_readings.FirstOrDefault(x => x.id == m_id);
                to_update.Previous_readings = to_update.Current_readings;
                to_update.Current_readings = c_meter;
                to_update.Date = today;
                _context.Entry(to_update).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();


                var s_id = _context.Fuel_category.FirstOrDefault(x => x.id == f_id).Station_id;
                var attendant_name = _context.System_users.FirstOrDefault(X => X.id.ToString() == (HttpContext.Session.GetString("id"))).Full_name;
                //RECORD SALES
                Individual_fuel_Sales_history x = new Individual_fuel_Sales_history()
                {
                    Date = today,
                    Fuel_id = f_id,
                    Previous_meter = p_meter,
                    Closing_meter = c_meter,
                    Litres_sold = sold,
                    Price = price,
                    Remaining_fuel = new_tank,
                    Cash_made = total,
                    Station_id = s_id,
                    Dispenser_id = m_id,
                    Attendant = attendant_name,
                };
                _context.Add(x);
                _context.SaveChanges();
                r.response_msg = "Success";


                return Json(r);

            }

            //INSERT SALES RECORDS
           
            

           
        }

    
        // POST: System_users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Full_name,Phone,Password,National_id,Roles")] System_users system_users)
        {
            if (ModelState.IsValid)
            {
                var check_if_admin_exists = _context.System_users.FirstOrDefault(x => x.Roles == 1);
                if (system_users.Roles == 1 && check_if_admin_exists != null)
                {
                    return View();
                }
                else
                {
                    var check_if_user_exist = _context.System_users.FirstOrDefault(x => x.National_id == system_users.National_id || x.Phone==system_users.Phone );
                    if (check_if_user_exist != null)
                    {
                        alert("Cannot create account", "warning", "ID NO: " + system_users.National_id + ", or Phone number: " + system_users.Phone + " is aldready registered in the system!");
                        return View();

                    }
                    else
                    {
                        _context.Add(system_users);
                        await _context.SaveChangesAsync();
                        alert("Success!", "success",system_users.Full_name+" registered successfully!");

                        return RedirectToAction(nameof(Index));
                    }

                }
              
            }
            return View(system_users);
        }

        internal void alert(string msg_type, string msg_header, string msg)
        {
            TempData.Clear();
            TempData.Remove("msg");
            TempData["msg"] = msg;
            TempData["msg_type"] = msg_type;
            TempData["msg_header"] = msg_header;
        }
        public void SendMessage(String message)
        {

            var SMS_Config = _context.SMS_Config.FirstOrDefault();
            var sms_phone = _context.System_users.FirstOrDefault(x => x.Roles == 1).Phone;

            TwilioClient.Init(SMS_Config.SSD, SMS_Config.Token);

            var message1 = MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber(SMS_Config.Phone),
                to: new Twilio.Types.PhoneNumber(sms_phone)
            );

            Console.WriteLine(message1.Sid);



        }
        // GET: System_users/Edit/5

        // GET: System_users/Delete/5

    }
    }

