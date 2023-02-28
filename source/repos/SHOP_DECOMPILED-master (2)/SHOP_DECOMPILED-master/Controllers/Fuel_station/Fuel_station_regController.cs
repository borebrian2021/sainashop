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

    public class Fuel_station_regController : Controller
    {
        private readonly ApplicationDBContext _context;

        public Fuel_station_regController(ApplicationDBContext context)
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
        // GET: Fuel_station_reg
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fuel_station_reg.ToListAsync());
        }

        // GET: Fuel_station_reg/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuel_station_reg = await _context.Fuel_station_reg
                .FirstOrDefaultAsync(m => m.id == id);
            if (fuel_station_reg == null)
            {
                return NotFound();
            }

            return View(fuel_station_reg);
        }

        // GET: Fuel_station_reg/Create
        public IActionResult Create()
        {
            try
            {
                ViewBag.user_id = _context.System_users.FirstOrDefault(x => x.Roles == 1).id;

            }
            catch(Exception ex)
            {
                TempData["msg"]= "Please register system owner!";
                TempData["msg_type"]= "warning";
              return  Redirect("~/System_users/create");
            }
            return View();
        }

        // POST: Fuel_station_reg/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Owners_id,Station_Name,Location")] Fuel_station_reg fuel_station_reg)
        {
            if (ModelState.IsValid)
            {
                var check_if_exist = _context.Fuel_station_reg.FirstOrDefault(x => x.Station_Name == fuel_station_reg.Station_Name || x.Location == fuel_station_reg.Location);
                if (check_if_exist == null)
                {
                    _context.Add(fuel_station_reg);
                    await _context.SaveChangesAsync();
                    alert("success", "Success!", "Station successfully registered");


                    return Redirect("~/Fuel_station_reg/index");
                }
                else
                {
                    alert("warning", "Warning!", "This fuel station is aldready registered!");
                    return View();
                }
               
            }
            else if (fuel_station_reg.Owners_id == null)
            {
                alert("warning", "Warning!", "Please check your inputs and try again!");

               

            }
            return View(fuel_station_reg);
        }

        // GET: Fuel_station_reg/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuel_station_reg = await _context.Fuel_station_reg.FindAsync(id);
            if (fuel_station_reg == null)
            {
                return NotFound();
            }
            try
            {

                ViewBag.user_id = _context.System_users.FirstOrDefault(x => x.Roles == 1).id;

            }
            catch(Exception ex)
            {

            }
            return View(fuel_station_reg);
        }

        // POST: Fuel_station_reg/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Owners_id,Station_Name,Location")] Fuel_station_reg fuel_station_reg)
        {
            if (id != fuel_station_reg.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fuel_station_reg);
                    await _context.SaveChangesAsync();
                    alert("success", "Success!", "Station details updated successfully!");


                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Fuel_station_regExists(fuel_station_reg.id))
                    {
                        alert("error", "Not found!", "Station not found!");

                        return NotFound();
                    }
                    else
                    {
                        alert("error", "Not found!", "Station not found!");

                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            return View(fuel_station_reg);
        }

        // GET: Fuel_station_reg/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuel_station_reg = await _context.Fuel_station_reg
                .FirstOrDefaultAsync(m => m.id == id);
            if (fuel_station_reg == null)
            {
                return NotFound();
            }

            return View(fuel_station_reg);
        }

        // POST: Fuel_station_reg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fuel_station_reg = await _context.Fuel_station_reg.FindAsync(id);
            var X = _context.Fuel_station_reg.FirstOrDefault(x => x.id == id).Station_Name;
            _context.Fuel_station_reg.Remove(fuel_station_reg);
            await _context.SaveChangesAsync();
                    alert("success", "Sucess!",X+ " deleted successfully!");

            return Redirect("~/Fuel_station_reg/index");
        }

        private bool Fuel_station_regExists(int id)
        {
            return _context.Fuel_station_reg.Any(e => e.id == id);
        }
    }
}
