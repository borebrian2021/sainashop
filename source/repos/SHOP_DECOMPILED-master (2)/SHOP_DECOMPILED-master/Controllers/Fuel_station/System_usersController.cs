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
using SHOP.Models;
using SHOP_DECOMPILED;
using SHOP_DECOMPILED.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
namespace SHOP_DECOMPILED.Controllers
{
    [Authorize]
    public class System_usersController : Controller
    {
        private readonly ApplicationDBContext _context;
        private static TimeZoneInfo E_Africa_standard_time = TimeZoneInfo.FindSystemTimeZoneById("E. Africa Standard Time");
        private static DateTime today1 = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, E_Africa_standard_time);
        string today = today1.ToString("dd/MM/yyyy");
        public System_usersController(ApplicationDBContext context)
        {
            _context = context;
        }
    
        internal void station_name(int station_id)
        {
            ViewBag.station_name = _context.Fuel_station_reg.FirstOrDefault(x => x.id == station_id).Station_Name;

        }
        public IActionResult Creditor_fuel(int id,int station_id)
        {
            HttpContext.Session.SetString("d_id", id.ToString());
            ViewBag.history = _context.Credits.Where(x => x.Client_id == id).ToList();
            var x = _context.Creditors_fuel.FirstOrDefault(x => x.id == id && x.station_id == station_id);
            if (x == null)
            {

            }
            else
            {
                ViewBag.debtors_name = x.Customer_name;
                ViewBag.id = id;
                ViewBag.station_id = station_id;
                ViewBag.Balance = x.Balance;
                //ViewBag.count_debtors = _context.Creditors.Count();
                ViewBag.history = _context.Credits_fuel.Where(x => x.Client_id == id);
                ViewBag.p_history = _context.Payment_history_fuel.Where(x=>x.Client_id==id).ToList();

            }

            return View();
        }
        public IActionResult payment(double ammount, int id,int station_id)
        {
            var initial_total = _context.Creditors_fuel.FirstOrDefault(x => x.id == id);
            var init = initial_total.Balance;
            var new_total = init - ammount;
            initial_total.Balance = new_total;
            _context.Entry(initial_total).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
         
            var date = DateTime.Now;
            Payment_history_fuel x = new Payment_history_fuel
            {
                Client_id = id,
                Ammount_paid = ammount,
                Balance = new_total,
                Date_created = date.ToString()
            };
            _context.Add(x);
            _context.SaveChanges();
            alert("Success", "success", "Payment submitted successfully!");
            return RedirectToAction("Creditor_fuel", "System_users", new { id = id,station_id=station_id });


        }
        public IActionResult _add_debt(int id, String fuel, String litres, string plate, double total,string date,string station_id)
        {
            var xx = _context.Creditors.FirstOrDefault(x => x.id == id);

            Credits_fuel x = new Credits_fuel
            {
                Client_id=id,
                Fuel = fuel,
                Ammount_in_litres = litres,
                Number_plate = plate,
                Total = total,
                Date_created=date


            };
            //var yy = _context.Creditors.FirstOrDefault(x => x.id == id);
            _context.Add(x);
            _context.SaveChanges();
            //UPDATE INITIAL CASH
            var before_ = _context.Creditors_fuel.FirstOrDefault(x => x.id == id);
            double initial_cash = before_.Balance;
            double new_cash = initial_cash + total;
            before_.Balance = new_cash;
            _context.Entry(before_).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            alert("Success", "success", "Fuel given on credit!");
            return RedirectToAction("Creditor_fuel", "System_users", new { id = id ,station_id=station_id});
        }
        public IActionResult add_debtor(String Full_name, int Phone,int station_id)
        {
            //LETS JOIN TABLES


            var check_if_item_exists1 = _context.Creditors_fuel.SingleOrDefault(x => x.Customer_name == Full_name || x.Phone_number == Phone && x.station_id==station_id);
            if (check_if_item_exists1  != null)
            {

                alert("Warning","warning", Full_name + " already exists! change name and try again");
                return RedirectToAction("Debtors", "System_users", new { station_id = station_id });

            }
            else
            {
                //var shop = _context.Creditors_fuel.FirstOrDefault(x => x.strRole == 1);

                Creditors_account_fuel client = new Creditors_account_fuel
                {
                    Customer_name = Full_name,
                    Phone_number = Phone,
                    station_id = station_id,
                    Date_created = DateTime.Now.ToString(),
                    Balance = 0
                };
                _context.Add(client);
                _context.SaveChanges();
              
                alert("Success!", "success", "Account created successfully!");

            }
            return RedirectToAction("Debtors", "System_users", new { station_id = station_id });

          

        }
        public IActionResult Debtors( int station_id)
        {
            ViewBag.station_id = station_id;
            //ViewBag.all_debtors = _context.Creditors_fuel.ToList();
            ViewBag.count_debtors = _context.Creditors_fuel.Where(x=>x.station_id==station_id).Count();
            ViewBag.sum_of_debts = _context.Creditors_fuel.Where(x=>x.station_id== station_id).Sum(x => x.Balance);
            ViewBag.all_debtors = _context.Creditors_fuel.Where(x => x.station_id == station_id).ToList();
            ViewBag.total_cash = _context.Individual_fuel_Sales_history.Where(x => x.Station_id == station_id && x.Date == today).Sum(x => x.Cash_made);
            return View();
        }
        // GET: System_users
        public async Task<IActionResult> Index()
        {
            return View(await _context.System_users.ToListAsync());
        }

        // GET: System_users/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var system_users = await _context.System_users
                .FirstOrDefaultAsync(m => m.id == id);
            if (system_users == null)
            {
                return NotFound();
            }

            return View(system_users);
        }

        [AllowAnonymous]
        // GET: System_users/Create
        public IActionResult Create()
        {
            dripdown_fuel_station();

            return View();
        }  
            public void join_meter_readinga(int station_id)
        {
            station_name(station_id);
            List<Meter_readings> meter_r = _context.Meter_readings.Where(x => x.Station_id == station_id).ToList();
            List<Fuel_category> fuel_c = _context.Fuel_category.Where(x => x.Station_id == station_id).ToList();
            List<Individual_fuel_Sales_history> individual_s = _context.Individual_fuel_Sales_history.Where(x => x.Station_id == station_id && x.Date==today).ToList();
            List<Relationship_meter_sales> joinList = new List<Relationship_meter_sales>();
            var results = (from fc in fuel_c
                         join mr in meter_r on fc.id equals mr.Fuel_id join fl in individual_s on mr.id equals fl.Dispenser_id
                           select new
                           {
                               mr.Label,
                               mr.Fuel_id,
                               mr.Current_readings,
                               mr.Previous_readings,
                               mr.Station_id,
                               fc.Current_quantity,
                               fc.Fuel_names,
                               fc.Price,
                               fc.Tank_capacity,
                               fc.id,
                               fl.Previous_meter,
                               fl.Closing_meter,
                               fl.Date,
                               fl.Dispenser_id,
                               fl.Cash_made,
                               fl.Remaining_fuel,
                               fl.Litres_sold,
                               fl.Attendant
                           }).ToList();

            foreach (var item in results)
            {
                Relationship_meter_sales JoinObject = new Relationship_meter_sales();

                JoinObject.Current_quantity = item.Current_quantity;
                JoinObject.Previous_readings = item.Previous_readings;

                JoinObject.Current_readings = item.Current_readings;
                JoinObject.Date = item.Date;
                JoinObject.fuel_id = item.Fuel_id;
                JoinObject.Fuel_names = item.Fuel_names;
                JoinObject.Label = item.Label;
                JoinObject.Tank_capacity = item.Tank_capacity;
                JoinObject.Station_id = item.Station_id;
                JoinObject.Price = item.Price;
                JoinObject.Previous_meter = item.Previous_meter;
                JoinObject.Closing_meter = item.Closing_meter;
                JoinObject.Dispenser_id = item.Dispenser_id;
                JoinObject.Cash_made = item.Cash_made;
                JoinObject.Remaining_fuel = item.Remaining_fuel;
                JoinObject.Litres_sold = item.Litres_sold;
                JoinObject.Litres_sold = item.Litres_sold;
                joinList.Add(JoinObject);

            }
            var JoinListToViewbag = joinList.ToList();

            ViewBag.submitted_meter = JoinListToViewbag;
        }
        [AllowAnonymous]
        public IActionResult log_out()
        {
            HttpContext.Session.Clear();
            alert("Signed out.", "success", "Thank you for your session!");
            return Redirect("~/System_users/log_in");
        }
        [Authorize]
        public IActionResult attendant( int station_id)
        {
            join_meter_readinga(station_id);
            HttpContext.Session.SetString("station_id", station_id.ToString());
            ViewBag.NAME = _context.System_users.FirstOrDefault(x => x.Roles == 2).Full_name;

            // LETS BIND SOLD ITEMS
            ViewBag.dubmitted = _context.Individual_fuel_Sales_history.Where(x => x.Station_id == station_id && x.Date == today).ToList();
            ViewBag.station_id = station_id;
            
            station_name(station_id);
            List<Meter_readings> meter_r = _context.Meter_readings.Where(x => x.Station_id == station_id).ToList();
            List<Fuel_category> fuel_c = _context.Fuel_category.Where(x=>x.Station_id==station_id).ToList();
            List<Relationship_meter> joinList = new List<Relationship_meter>();
            var results = (from pd in meter_r
                           join od in fuel_c on pd.Fuel_id equals od.id
                           select new
                           {
                               pd.Label,
                               pd.Fuel_id,
                               pd.Current_readings,
                               pd.Previous_readings,
                               pd.Station_id,
                               od.Current_quantity,
                               od.Fuel_names,
                               od.Price,
                               od.Tank_capacity,
                               pd.id,
                               pd.Date,
                               od.fuel_id


                           }).ToList();

            foreach (var item in results)
            {
                Relationship_meter JoinObject = new Relationship_meter();

                JoinObject.Current_quantity = item.Current_quantity;
                JoinObject.Previous_readings = item.Previous_readings;
                JoinObject.id = item.id;

                JoinObject.Current_readings = item.Current_readings;
                JoinObject.Date = item.Date;
                JoinObject.fuel_id = item.Fuel_id;
                JoinObject.Fuel_names = item.Fuel_names;
                JoinObject.Label = item.Label;
                JoinObject.Tank_capacity = item.Tank_capacity;
                JoinObject.Station_id = item.Station_id;
                JoinObject.Price = item.Price;
                joinList.Add(JoinObject);

            }
            var JoinListToViewbag = joinList.ToList();

            ViewBag.Meter_details = JoinListToViewbag;
            //var c = _context.Fuel_station_reg.FirstOrDefault(x => x.id == station_id).Station_Name;

            //var Availlable_fuel=_context.Meter_readings.
            //alert("success", "Loged in successfylly", "Wlcome back!");
            ViewBag.fuel_category = _context.Fuel_category.Where(x=>x.Station_id==station_id).ToList();
            return View();
        }
        [Authorize (Roles ="1")]
        public IActionResult admin(int station_id)
        {
            HttpContext.Session.SetString("station_id", station_id.ToString());

            ViewBag.fuel_category = _context.Fuel_category.Where(x=>x.Station_id==station_id).ToList();
            ViewBag.NAME = _context.System_users.FirstOrDefault(x=>x.Roles==1).Full_name;

            station_name(station_id);
            List<Meter_readings> meter_r = _context.Meter_readings.Where(x => x.Station_id == station_id).ToList();
            List<Fuel_category> fuel_c = _context.Fuel_category.Where(x => x.Station_id == station_id).ToList();
            List<Relationship_meter> joinList = new List<Relationship_meter>();
            var results = (from pd in meter_r
                           join od in fuel_c on pd.Fuel_id equals od.id
                           select new
                           {
                               pd.Label,
                               pd.Fuel_id,
                               pd.Current_readings,
                               pd.Previous_readings,
                               pd.Station_id,
                               od.Current_quantity,
                               od.Fuel_names,
                               od.Price,
                               od.Tank_capacity,
                               pd.id,
                               pd.Date,
                               od.fuel_id


                           }).ToList();

            foreach (var item in results)
            {
                Relationship_meter JoinObject = new Relationship_meter();

                JoinObject.Current_quantity = item.Current_quantity;
                JoinObject.Previous_readings = item.Previous_readings;
                JoinObject.id = item.id;

                JoinObject.Current_readings = item.Current_readings;
                JoinObject.Date = item.Date;
                JoinObject.fuel_id = item.Fuel_id;
                JoinObject.Fuel_names = item.Fuel_names;
                JoinObject.Label = item.Label;
                JoinObject.Tank_capacity = item.Tank_capacity;
                JoinObject.Station_id = item.Station_id;
                JoinObject.Price = item.Price;
                joinList.Add(JoinObject);

            }
            var JoinListToViewbag = joinList.ToList();
            ViewBag.Meter_details = _context.Fuel_category.Where(x => x.Station_id == station_id).ToList();
            ViewBag.Station_name = _context.Fuel_station_reg.Where(x => x.id == station_id).FirstOrDefault().Station_Name;
            ViewBag.username = _context.System_users.FirstOrDefault(x => x.National_id.ToString() == HttpContext.Session.GetString("national_id"));
            ViewBag.Count_Attendants = _context.System_users.Where(x=>x.Roles==2).Count();
            ViewBag.Debtors = _context.Creditors_fuel.Where(x => x.station_id == station_id).Count();
            ViewBag.total_cash = _context.Individual_fuel_Sales_history.Where(x => x.Station_id == station_id &&x.Date==today).Sum(x => x.Cash_made);
            ViewBag.Meter = _context.Meter_readings.Where(x => x.Station_id == station_id).ToList();


            List<LineChartData> chartData = new List<LineChartData>
            {
                new LineChartData { xValue = new DateTime(2005, 01, 01), yValue = 21, yValue1 = 28 },
                new LineChartData { xValue = new DateTime(2006, 01, 01), yValue = 24, yValue1 = 44 },
                new LineChartData { xValue = new DateTime(2007, 01, 01), yValue = 36, yValue1 = 48 },
                new LineChartData { xValue = new DateTime(2008, 01, 01), yValue = 38, yValue1 = 50 },
                new LineChartData { xValue = new DateTime(2009, 01, 01), yValue = 54, yValue1 = 66 },
                new LineChartData { xValue = new DateTime(2010, 01, 01), yValue = 57, yValue1 = 78 },
                new LineChartData { xValue = new DateTime(2011, 01, 01), yValue = 70, yValue1 = 84 },
            };
            ViewBag.dataSource = chartData;
            HttpContext.Session.SetString("station_id", station_id.ToString());
            return View();
        }
       
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Log_in_user(int id,string password)
        {
            string pass = password;
            TokenProvider_admin TokenProviderr = new TokenProvider_admin(_context);
            string userToken = TokenProviderr.LoginUser(id, password);
            if (userToken == null)
            {
                alert("Fail", "warning", "Wrong username or password!");
                return Redirect("~/System_users/Log_in");
            }
            HttpContext.Session.SetString("JWToken", userToken);
            System_users user_id = _context.System_users.Where(x => x.National_id == id).SingleOrDefault();
            if (user_id.Roles == 1)
            {
                HttpContext.Session.SetString("id", user_id.id.ToString());
                //HttpContext.Session.SetString("station_id", user_id.id.ToString());
                alert("Success", "success", "Logged in successfully!");
                return RedirectToAction("Admin", "System_users", new { station_id = user_id.station_id });

            }
            else
            {
                HttpContext.Session.SetString("id", user_id.id.ToString());
                
                alert("Success", "success", "Logged in successfully!");

                return RedirectToAction("Attendant", "System_users", new {  station_id = user_id.station_id });


            }

        }
        [AllowAnonymous]
        public IActionResult log_in(int id,string password)
        {
              

            return View();
        }
             [AllowAnonymous]
           public IActionResult landing_page()
        {
              

            return View();
        }
          
        [AllowAnonymous]
           public IActionResult testing()
        {
            List<LineChartData> chartData = new List<LineChartData>
            {
                new LineChartData { xValue = new DateTime(2005, 01, 01), yValue = 21, yValue1 = 28 },
                new LineChartData { xValue = new DateTime(2006, 01, 01), yValue = 24, yValue1 = 44 },
                new LineChartData { xValue = new DateTime(2007, 01, 01), yValue = 36, yValue1 = 48 },
                new LineChartData { xValue = new DateTime(2008, 01, 01), yValue = 38, yValue1 = 50 },
                new LineChartData { xValue = new DateTime(2009, 01, 01), yValue = 54, yValue1 = 66 },
                new LineChartData { xValue = new DateTime(2010, 01, 01), yValue = 57, yValue1 = 78 },
                new LineChartData { xValue = new DateTime(2011, 01, 01), yValue = 70, yValue1 = 84 },
            };
            ViewBag.dataSource = chartData;
            return View();

        }

   public class LineChartData
        {
            public DateTime xValue;
            public double yValue;
            public double yValue1;
        }
       

        public void dripdown_fuel_station()
        {
            List<Fuel_station_reg> x = new List<Fuel_station_reg>();
            //bind dropdown
            x = _context.Fuel_station_reg.ToList();
            x.Insert(0, new Fuel_station_reg { id = 0, Station_Name = "--Select station--" });
            ViewBag.Drop_sulier = x;

        }
        // POST: System_users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [AllowAnonymous]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Full_name,Phone,Password,National_id,Roles,station_id")] System_users system_users)
        {
            dripdown_fuel_station();
            if (ModelState.IsValid)

            {
                var check_if_admin_exists = _context.System_users.FirstOrDefault(x => x.Roles == 1);
                if (system_users.Roles == 1 && check_if_admin_exists != null)
                {
                    alert("Cannot create account", "warning", "Only one administrator is required!");

                    return View();
                }
                else
                {
                    var check_if_user_exist = _context.System_users.FirstOrDefault(x => x.National_id == system_users.National_id || x.Phone==system_users.Phone );
                    if (check_if_user_exist != null)
                    {
                        alert("Cannot create account", "warning", "ID NO: " + system_users.National_id + ", or Phone number: " + check_if_user_exist.Phone + " is aldready registered in the system!");
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

        internal void alert(string msg_header, string msg_type, string msg)
        {
            TempData.Clear();
            TempData.Remove("msg");
            TempData["msg"] = msg;
            TempData["msg_type"] = msg_type;
            TempData["msg_header"] = msg_header;
        }
        // GET: System_users/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var system_users = await _context.System_users.FindAsync(id);
            if (system_users == null)
            {
                return NotFound();
            }
            return View(system_users);
        }

        // POST: System_users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Full_name,Phone,Password,National_id,Roles")] System_users system_users)
        {
            if (id != system_users.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(system_users);
                    await _context.SaveChangesAsync();
                    alert("Account updated", "success", system_users.Full_name+" account updataed successfully!");

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!System_usersExists(system_users.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(system_users);
        }

        // GET: System_users/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var system_users = await _context.System_users
                .FirstOrDefaultAsync(m => m.id == id);
            if (system_users == null)
            {
                return NotFound();
            }

            return View(system_users);
        }

        // POST: System_users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var system_users = await _context.System_users.FindAsync(id);
            alert("Success!", "success", system_users.Full_name + " Account deleted successfully!");

            _context.System_users.Remove(system_users);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool System_usersExists(int id)
        {
            return _context.System_users.Any(e => e.id == id);
        }

        public class ajax_call_back{
           public string response;
            }
        [HttpPost]

        
        public JsonResult check_meter_validity(string name)
        {
            //var rol = User.Identity.Name;
            //if (rol == "1")
            //{
            ajax_call_back person = new ajax_call_back
            {

                response = name

            };

            return Json(person);

            //}

           
        }
      
    }
}
