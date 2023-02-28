using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lubes.DBContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SHOP_DECOMPILED;
using SHOP_DECOMPILED.Models;

namespace SHOP_DECOMPILED.Controllers
{
    [Authorize]
    public class Meter_readingsController : Controller
    {
        private readonly ApplicationDBContext _context;
        private static TimeZoneInfo E_Africa_standard_time = TimeZoneInfo.FindSystemTimeZoneById("E. Africa Standard Time");
        private static DateTime today1 = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, E_Africa_standard_time);
        string today = today1.ToString("dd/MM/yyyy");
        public Meter_readingsController(ApplicationDBContext context)
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
        internal void station_name(int station_id)
        {
            ViewBag.station_name = _context.Fuel_station_reg.FirstOrDefault(x => x.id == station_id).Station_Name;

        }

        // GET: Meter_readings
        public IActionResult Index(int station_id)
        {
            var meter_readings = _context.Meter_readings.Where(x => x.Station_id == station_id).ToList();
            ViewBag.station_id = station_id;
            station_name(station_id);
            return View(meter_readings);
        }

        // GET: Meter_readings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meter_readings = await _context.Meter_readings
                .FirstOrDefaultAsync(m => m.id == id);
            if (meter_readings == null)
            {
                return NotFound();
            }

            return View(meter_readings);
        }

        // GET: Meter_readings/Create
        public IActionResult Create( int station_id)
        {
            ViewBag.station_id = station_id;
            station_name(station_id);
            List<Fuel_category> x = new List<Fuel_category>();
            //bind dropdown
            x = _context.Fuel_category.Where(x => x.Station_id == station_id).ToList();
            x.Insert(0, new Fuel_category { id = 0, Fuel_names = "--Select fuel--" });
            if (station_id == 0)
            {
                alert("warning", "No fuel category found", "Please select fuel station and add fuel category.");
                return Redirect("~/Fuel_station_reg/index");
            }
            else
            {
                ViewBag.Drop_sulier = x;
                return View();
            }
        }

        // POST: Meter_readings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Label,Fuel_id,Current_readings,Previous_readings,Date,Agent_id,Station_id")] Meter_readings meter_readings)
        {

           

            if (ModelState.IsValid)
            {
                var xC = _context.Meter_readings.Where(x => x.Label == meter_readings.Label).ToList();
                if (xC.Count() > 0)
                {
                    alert("warning", "Warning!", "You have already added : ");
                    //Redirect("~/Meter_readings/index/")
            return RedirectToAction("index", "Meter_readings", new { @station_id = meter_readings.Station_id });

                }
                else
                {
                    var s_id = meter_readings.Station_id;
                    _context.Add(meter_readings);
                    await _context.SaveChangesAsync();
                    alert("success", "Success!", "Meter readings recorded successfully! ");
                    return RedirectToAction("index", "Meter_readings", new { @station_id = s_id });
                }

            }
            else
            {
                ViewBag.station_id = meter_readings.Station_id;


                List<Fuel_category> x = new List<Fuel_category>();
                //bind dropdown
                x = _context.Fuel_category.Where(x => x.Station_id == meter_readings.Station_id).ToList();
                x.Insert(0, new Fuel_category { id = 0, Fuel_names = "--Select fuel--" });
                ViewBag.Drop_sulier = x;
                return View(meter_readings);

            }
        }

        // GET: Meter_readings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            var xc = _context.Meter_readings.FirstOrDefault(x => x.id == id);
            var station_id = xc.Station_id;
            ViewBag.label = xc.Label;
            ViewBag.station_id = station_id;
          
            List<Fuel_category> x = new List<Fuel_category>();
            //bind dropdown
            x = _context.Fuel_category.Where(x => x.Station_id == station_id).ToList();
            x.Insert(0, new Fuel_category { id = 0, Fuel_names = "--Select Fuel--" });
            ViewBag.Drop_sulier = x;
            station_name(station_id);
            if (id == null)
            {
                return NotFound();
            }

            var meter_readings = await _context.Meter_readings.FindAsync(id);
            if (meter_readings == null)
            {
                return NotFound();
            }
            return View(meter_readings);
        }

        // POST: Meter_readings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Label,Fuel_id,Current_readings,Previous_readings,Date,Agent_id,Station_id")] Meter_readings meter_readings)
        {
            var x = meter_readings.Station_id;
            if (id != meter_readings.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meter_readings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Meter_readingsExists(meter_readings.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                alert("success", "Success!", "Updated  successfully! ");

                return RedirectToAction("index", "Meter_readings", new { @station_id = x });

            }
            var xc = _context.Meter_readings.FirstOrDefault(x => x.id == id);
            var station_idx = xc.Station_id;
            ViewBag.label = xc.Label;
            ViewBag.station_id = station_idx;
            var station_id = _context.Meter_readings.FirstOrDefault(x => x.id == id).Station_id;
            List<Fuel_category> xy = new List<Fuel_category>();
            //bind dropdown
            xy = _context.Fuel_category.Where(x => x.Station_id == station_id).ToList();
            xy.Insert(0, new Fuel_category { id = 0, Fuel_names = "--Select Fuel--" });
            ViewBag.Drop_sulier = xy;
            return View(meter_readings);
        }

        // GET: Meter_readings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meter_readings = await _context.Meter_readings
                .FirstOrDefaultAsync(m => m.id == id);
            if (meter_readings == null)
            {
                return NotFound();
            }

            return View(meter_readings);
        }

        // POST: Meter_readings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meter_readings = await _context.Meter_readings.FindAsync(id);
            var x = _context.Meter_readings.FirstOrDefault(x => x.id == id);
            var y = x.Station_id;
            _context.Meter_readings.Remove(meter_readings);
            await _context.SaveChangesAsync();
            alert("success", "Success!", "Deleted  successfully! ");

            return RedirectToAction("index", "Meter_readings", new { @station_id = y });

        }

        private bool Meter_readingsExists(int id)
        {
            return _context.Meter_readings.Any(e => e.id == id);
        }
    }
}
