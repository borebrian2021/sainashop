using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lubes.DBContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rentals_mtaani_3.Controllers;
using SHOP_DECOMPILED;
using SHOP_DECOMPILED.Models;

namespace SHOP_DECOMPILED.Controllers
{
    [Authorize]
    public class Individual_fuel_Sales_historyController : BaseController<Relationship_meter_sales>
    {
        private readonly ApplicationDBContext _context;
        private static TimeZoneInfo E_Africa_standard_time = TimeZoneInfo.FindSystemTimeZoneById("E. Africa Standard Time");
        private static DateTime today1 = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, E_Africa_standard_time);
        string today = today1.ToString("dd/MM/yyyy");
        public Individual_fuel_Sales_historyController(ApplicationDBContext context)
        {
            _context = context;
        }
         
        public void recent_sales(int station_id)
        {
            List<Meter_readings> meter_r = _context.Meter_readings.Where(x => x.Station_id == station_id).ToList();
            List<Fuel_category> fuel_c = _context.Fuel_category.Where(x => x.Station_id == station_id).ToList();
            List<Individual_fuel_Sales_history> individual_s = _context.Individual_fuel_Sales_history.Where(x => x.Station_id == station_id && x.Date==today).ToList();
            List<Relationship_meter_sales> joinList = new List<Relationship_meter_sales>();
            var results = (from fc in fuel_c
                           join mr in meter_r on fc.id equals mr.Fuel_id
                           join fl in individual_s on mr.id equals fl.Dispenser_id
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
                               fl.Attendant,

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
                JoinObject.Attendant = item.Attendant;
                joinList.Add(JoinObject);

            }
            var JoinListToViewbag = joinList.ToList();

            ViewBag.litres_sold = _context.Individual_fuel_Sales_history.Where(x=>x.Station_id==station_id &&x.Date==today).Sum(x => x.Litres_sold);
            ViewBag.cash_made = _context.Individual_fuel_Sales_history.Where(x=>x.Station_id==station_id &&x.Date==today).Sum(x => x.Cash_made);
            ViewBag.submitted_meter = JoinListToViewbag;
        }

        // GET: Individual_fuel_Sales_history
        public async Task<IActionResult> sales_per_day(int station_id, String Date)
        {
            string day;
            recent_sales(station_id);
            if (Date == null)
            {
                 day = "Not records availlable for this date";
            }
            else
            {
                DateTime dateTime = DateTime.ParseExact(Date, "yyyy-MM-dd", null);
                day = dateTime.ToString("dd/MM/yyyy");
            }
           
            recent_sales(station_id);
            List<Meter_readings> meter_r = _context.Meter_readings.Where(x => x.Station_id == station_id).ToList();
            List<Fuel_category> fuel_c = _context.Fuel_category.Where(x => x.Station_id == station_id).ToList();
            List<Individual_fuel_Sales_history> individual_s = _context.Individual_fuel_Sales_history.Where(x => x.Station_id == station_id && x.Date== day.ToString()).ToList();
            List<Relationship_meter_sales> joinList = new List<Relationship_meter_sales>();
            var results = (from fc in fuel_c
                           join mr in meter_r on fc.id equals mr.Fuel_id
                           join fl in individual_s on mr.id equals fl.Dispenser_id
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
                joinList.Add(JoinObject);

            }
            var JoinListToViewbag = joinList.ToList();
            ViewBag.all_submitted_sales = JoinListToViewbag;
            ViewBag.litres_sold = _context.Individual_fuel_Sales_history.Where(x => x.Station_id == station_id && x.Date == day.ToString()).Sum(x => x.Litres_sold);
            ViewBag.cash_made = _context.Individual_fuel_Sales_history.Where(x => x.Station_id == station_id && x.Date == day.ToString()).Sum(x => x.Cash_made);
            ViewBag.s_id = station_id;
            ViewBag.date = day;
            return View(await _context.Individual_fuel_Sales_history.ToListAsync());
        }  
        public async Task<IActionResult> Index(int station_id)
        {
            recent_sales(station_id);
            List<Meter_readings> meter_r = _context.Meter_readings.Where(x => x.Station_id == station_id).ToList();
            List<Fuel_category> fuel_c = _context.Fuel_category.Where(x => x.Station_id == station_id).ToList();
            List<Individual_fuel_Sales_history> individual_s = _context.Individual_fuel_Sales_history.Where(x => x.Station_id == station_id).ToList();
            List<Relationship_meter_sales> joinList = new List<Relationship_meter_sales>();
            var results = (from fc in fuel_c
                           join mr in meter_r on fc.id equals mr.Fuel_id
                           join fl in individual_s on mr.id equals fl.Dispenser_id
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
                JoinObject.Attendant = item.Attendant;
                joinList.Add(JoinObject);

            }
            var JoinListToViewbag = joinList.ToList();
            ViewBag.all_submitted_sales = JoinListToViewbag;
            ViewBag.s_id = station_id;

            return View(await _context.Individual_fuel_Sales_history.ToListAsync());
        }

        // GET: Individual_fuel_Sales_history/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var individual_fuel_Sales_history = await _context.Individual_fuel_Sales_history
                .FirstOrDefaultAsync(m => m.id == id);
            if (individual_fuel_Sales_history == null)
            {
                return NotFound();
            }

            return View(individual_fuel_Sales_history);
        }

        // GET: Individual_fuel_Sales_history/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Individual_fuel_Sales_history/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Date,Fuel_id,Litres_sold,Price,Remaining_fuel,Cash_made")] Individual_fuel_Sales_history individual_fuel_Sales_history)
        {
            if (ModelState.IsValid)
            {
                _context.Add(individual_fuel_Sales_history);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(individual_fuel_Sales_history);
        }

        // GET: Individual_fuel_Sales_history/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var individual_fuel_Sales_history = await _context.Individual_fuel_Sales_history.FindAsync(id);
            if (individual_fuel_Sales_history == null)
            {
                return NotFound();
            }
            return View(individual_fuel_Sales_history);
        }

        // POST: Individual_fuel_Sales_history/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Date,Fuel_id,Litres_sold,Price,Remaining_fuel,Cash_made")] Individual_fuel_Sales_history individual_fuel_Sales_history)
        {
            if (id != individual_fuel_Sales_history.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(individual_fuel_Sales_history);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Individual_fuel_Sales_historyExists(individual_fuel_Sales_history.id))
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
            return View(individual_fuel_Sales_history);
        }

        // GET: Individual_fuel_Sales_history/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var individual_fuel_Sales_history = await _context.Individual_fuel_Sales_history
                .FirstOrDefaultAsync(m => m.id == id);
            if (individual_fuel_Sales_history == null)
            {
                return NotFound();
            }

            return View(individual_fuel_Sales_history);
        }

        // POST: Individual_fuel_Sales_history/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var individual_fuel_Sales_history = await _context.Individual_fuel_Sales_history.FindAsync(id);
            _context.Individual_fuel_Sales_history.Remove(individual_fuel_Sales_history);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Individual_fuel_Sales_historyExists(int id)
        {
            return _context.Individual_fuel_Sales_history.Any(e => e.id == id);
        }
    }
}
