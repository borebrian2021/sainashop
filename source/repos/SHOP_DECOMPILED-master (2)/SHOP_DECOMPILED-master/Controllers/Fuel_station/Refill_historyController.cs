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
    public class Refill_historyController : Controller
    {
        private readonly ApplicationDBContext _context;

        public Refill_historyController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: Refill_history
        public async Task<IActionResult> Index()
        {
            return View(await _context.Refill_history.ToListAsync());
        }

        // GET: Refill_history/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refill_history = await _context.Refill_history
                .FirstOrDefaultAsync(m => m.id == id);
            if (refill_history == null)
            {
                return NotFound();
            }

            return View(refill_history);
        }

        // GET: Refill_history/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Refill_history/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Fuel_id,Ammount_refilled,Date_refilled,initial_readings,final_readings,agent_id")] Refill_history refill_history)
        {
            if (ModelState.IsValid)
            {
                _context.Add(refill_history);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(refill_history);
        }

        // GET: Refill_history/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refill_history = await _context.Refill_history.FindAsync(id);
            if (refill_history == null)
            {
                return NotFound();
            }
            return View(refill_history);
        }

        // POST: Refill_history/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Fuel_id,Ammount_refilled,Date_refilled,initial_readings,final_readings,agent_id")] Refill_history refill_history)
        {
            if (id != refill_history.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(refill_history);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Refill_historyExists(refill_history.id))
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
            return View(refill_history);
        }

        // GET: Refill_history/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var refill_history = await _context.Refill_history
                .FirstOrDefaultAsync(m => m.id == id);
            if (refill_history == null)
            {
                return NotFound();
            }

            return View(refill_history);
        }

        // POST: Refill_history/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var refill_history = await _context.Refill_history.FindAsync(id);
            _context.Refill_history.Remove(refill_history);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Refill_historyExists(int id)
        {
            return _context.Refill_history.Any(e => e.id == id);
        }
    }
}
