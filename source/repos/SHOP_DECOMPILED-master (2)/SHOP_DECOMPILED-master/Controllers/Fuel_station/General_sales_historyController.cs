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
    public class General_sales_historyController : Controller
    {
        private readonly ApplicationDBContext _context;

        public General_sales_historyController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: General_sales_history
        public async Task<IActionResult> Index()
        {
            return View(await _context.General_sales_history.ToListAsync());
        }

        // GET: General_sales_history/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var general_sales_history = await _context.General_sales_history
                .FirstOrDefaultAsync(m => m.id == id);
            if (general_sales_history == null)
            {
                return NotFound();
            }

            return View(general_sales_history);
        }

        // GET: General_sales_history/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: General_sales_history/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Attendant_id,Total_cash_made,Cash_paybill,Cash_at_hand,Expenses,On_credit,Availlable_cash")] General_sales_history general_sales_history)
        {
            if (ModelState.IsValid)
            {
                _context.Add(general_sales_history);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(general_sales_history);
        }

        // GET: General_sales_history/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var general_sales_history = await _context.General_sales_history.FindAsync(id);
            if (general_sales_history == null)
            {
                return NotFound();
            }
            return View(general_sales_history);
        }

        // POST: General_sales_history/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Attendant_id,Total_cash_made,Cash_paybill,Cash_at_hand,Expenses,On_credit,Availlable_cash")] General_sales_history general_sales_history)
        {
            if (id != general_sales_history.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(general_sales_history);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!General_sales_historyExists(general_sales_history.id))
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
            return View(general_sales_history);
        }

        // GET: General_sales_history/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var general_sales_history = await _context.General_sales_history
                .FirstOrDefaultAsync(m => m.id == id);
            if (general_sales_history == null)
            {
                return NotFound();
            }

            return View(general_sales_history);
        }

        // POST: General_sales_history/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var general_sales_history = await _context.General_sales_history.FindAsync(id);
            _context.General_sales_history.Remove(general_sales_history);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool General_sales_historyExists(int id)
        {
            return _context.General_sales_history.Any(e => e.id == id);
        }
    }
}
