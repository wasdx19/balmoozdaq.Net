using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using balmoozdaq.Data;
using balmoozdaq.Models;

namespace balmoozdaq.Controllers
{
    public class WeekdayController : Controller
    {
        private readonly BalmoozdaqContext _context;

        public WeekdayController(BalmoozdaqContext context)
        {
            _context = context;
        }

        // GET: Weekday
        public async Task<IActionResult> Index()
        {
            return View(await _context.Weekday.ToListAsync());
        }

        // GET: Weekday/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weekday = await _context.Weekday
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weekday == null)
            {
                return NotFound();
            }

            return View(weekday);
        }

        // GET: Weekday/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Weekday/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Weekday weekday)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weekday);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(weekday);
        }

        // GET: Weekday/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weekday = await _context.Weekday.FindAsync(id);
            if (weekday == null)
            {
                return NotFound();
            }
            return View(weekday);
        }

        // POST: Weekday/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Weekday weekday)
        {
            if (id != weekday.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weekday);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeekdayExists(weekday.Id))
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
            return View(weekday);
        }

        // GET: Weekday/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weekday = await _context.Weekday
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weekday == null)
            {
                return NotFound();
            }

            return View(weekday);
        }

        // POST: Weekday/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weekday = await _context.Weekday.FindAsync(id);
            _context.Weekday.Remove(weekday);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeekdayExists(int id)
        {
            return _context.Weekday.Any(e => e.Id == id);
        }
    }
}
