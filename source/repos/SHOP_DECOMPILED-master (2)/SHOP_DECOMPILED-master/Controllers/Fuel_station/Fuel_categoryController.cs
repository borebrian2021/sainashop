using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lubes.DBContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SHOP.Models;
using SHOP_DECOMPILED;
using SHOP_DECOMPILED.Models;


namespace SHOP_DECOMPILED.Controllers
{
    [Authorize]
    public class Fuel_categoryController : Controller
    {
        private readonly ApplicationDBContext _context;

        public Fuel_categoryController(ApplicationDBContext context)
        {
            _context = context;
        }
        internal void alert(string msg_type, string msg_header, string msg)
        {
            TempData.Clear();
            TempData.Remove("msg");
            TempData["msg"] = msg;
            TempData["msg_type"] = msg_type;
            TempData["msg_header"] = msg_header;
        }
        // GET: Fuel_category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> change_sms_settings(double level,int fuel_id,string status)
        {
            var records = _context.SMS_Settings.FirstOrDefault(x => x.Fuel_id == fuel_id.ToString());
            
            records.Level = level;
            records.status = status;

            //DATESET
            records.Last_set = DateTime.Now.ToString();
            _context.Entry(records).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            alert("success", "Success!", "You have successfully set the level to be notified of fuel status. SMS Notification will be sent to the administrator when fuel level goes below: " + level + " litres!");
            return Redirect("~/Fuel_category/Details/" + fuel_id);
        }
        public IActionResult Index(int station_id)
        {
            var filtered_station = _context.Fuel_category.Where(x => x.Station_id == station_id).ToList();
            if (station_id == 0)
            {
                alert("warning", "Warning", "Please select fuel station first!");
                return Redirect("~/Fuel_station_reg/index");
                //return Content(station_id.ToString());
            }
            else
            {
                ViewBag.station_id = station_id;
                var station_name = _context.Fuel_station_reg.FirstOrDefault(x => x.id == station_id);
                //alert("info", "For your information.", "This page is for uploading fuel category e.g. Super & Diese. Fuel station:" + station_name.Station_Name);

                return View(filtered_station);

            }
        }

        // GET: Fuel_category/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.sms_status = _context.SMS_Settings.FirstOrDefault(x => x.Fuel_id == id.ToString()).status;
            var fuel_category = await _context.Fuel_category
                .FirstOrDefaultAsync(m => m.id == id);
            if (fuel_category == null)
            {
                return NotFound();
            }
            var x = _context.Fuel_category.FirstOrDefault(x => x.id == id);
            var station_id = x.Station_id;

            var y = _context.Fuel_station_reg.FirstOrDefault(x => x.id == station_id);

            var station_name = y.Station_Name;

            ViewBag.Station = station_name;
            ViewBag.Fuel_level = _context.SMS_Settings.FirstOrDefault(x => x.Fuel_id == id.ToString()).Level;
            ViewBag.last_set = _context.SMS_Settings.FirstOrDefault(x => x.Fuel_id == id.ToString()).Last_set;

            return View(fuel_category);
        }

        // GET: Fuel_category/Create
        public IActionResult Create( int station_id)
        {

            if (station_id == 0)
            {
                alert("warning", "Warning", "Please select the station in order to proceed!");
                return Redirect("~/Fuel_station/index");

            }
            else
            {
                var station_d = _context.Fuel_station_reg.FirstOrDefault(x => x.id == station_id);
                ViewBag.station_id = station_id;
                //alert("info", "For your information", "You are accessing fuel sold at: "+station_d.Station_Name);

            }
            return View();
        }

        // POST: Fuel_category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Fuel_names,Tank_capacity,Current_quantity,Price,Station_id")] Fuel_category fuel_category)
        {
            if (ModelState.IsValid)
            {
                var station_id = fuel_category.Station_id;
                if (fuel_category.Current_quantity > fuel_category.Tank_capacity)
                {
                    alert("error", "Fail", "The entered fuel capacity value is greater that actual tank capacity.Please check and try again!");
                    return View();
                }
                else
                {
                    var check = _context.Fuel_category.Where(x => x.Fuel_names == fuel_category.Fuel_names && x.Station_id==fuel_category.Station_id).ToList();
                    if (check.Count()>0)
                    {
                        alert("warning", "Warrning", fuel_category.Fuel_names + " is already in the system");
                        return View();

                      

                    }
                    else
                    {
                        _context.Add(fuel_category);
                        await _context.SaveChangesAsync();
                        var fuel_id = _context.Fuel_category.FirstOrDefault(x => x.Fuel_names == fuel_category.Fuel_names).id;

                        SMS_Settings x = new SMS_Settings()
                        {
                            Fuel_id = fuel_id.ToString(),
                            Level = 0,
                            Last_set = DateTime.Now.ToString(),
                        };
                        _context.Add(x);
                        await _context.SaveChangesAsync();


                       
                        alert("success", "Success!", "Fuel category successfully added! NB:Default fuel level for SMS notification is 0, Go to fuel details to customize it.");
                        //return Redirect("~/Fuel_category/index/?station_id");
                        return RedirectToAction("index", "Fuel_category", new { @station_id = station_id });
                    }
                }

            }
            return View(fuel_category);
        }

        // GET: Fuel_category/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuel_category = await _context.Fuel_category.FindAsync(id);
            if (fuel_category == null)
            {
                return NotFound();
            }
            return View(fuel_category);
        }

        // POST: Fuel_category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Fuel_names,Tank_capacity,Current_quantity,Price,Station_id")] Fuel_category fuel_category)
        {
            if (id != fuel_category.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    if (fuel_category.Current_quantity > fuel_category.Tank_capacity)
                {
                    alert("error", "Fail", "The entered fuel capacity value is greater that actual tank capacity.Please check and try again!");
                    return View();
                }
                else
                {
                    //var check = _context.Fuel_category.Where(x => x.Fuel_names == fuel_category.Fuel_names).ToList();
                   
                        _context.Update(fuel_category);
                        await _context.SaveChangesAsync();
                        alert("success", "Success!", "Fuel category successfully updated!");
                        return RedirectToAction(nameof(Index));
                    
                }
              
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Fuel_categoryExists(fuel_category.id))
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
            return View(fuel_category);
        }

        // GET: Fuel_category/
        // /5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuel_category = await _context.Fuel_category
                .FirstOrDefaultAsync(m => m.id == id);
            if (fuel_category == null)
            {
                return NotFound();
            }

            return View(fuel_category);
        }

        // POST: Fuel_category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fuel_category = await _context.Fuel_category.FindAsync(id);
            var x = fuel_category.Fuel_names;
            var station_id = _context.Fuel_category.FirstOrDefault(x => x.id == id);

            _context.Fuel_category.Remove(fuel_category);
            await _context.SaveChangesAsync();
            var s_id = station_id.fuel_id;


            var sms_settings =  _context.SMS_Settings.FirstOrDefault(x => x.Fuel_id == id.ToString());
            _context.SMS_Settings.Remove(sms_settings);
            await _context.SaveChangesAsync();
            alert("success", "Success!", x+" successfully removed from the system!:Note:All information related to this fuel such as meter readings,and sms settings has been removed!");
            return RedirectToAction("index", "Fuel_category", new { @station_id = s_id });

            //return Redirect("~/Fuel_category/index");
        }

        private bool Fuel_categoryExists(int id)
        {
            return _context.Fuel_category.Any(e => e.id == id);
        }
    }
}
