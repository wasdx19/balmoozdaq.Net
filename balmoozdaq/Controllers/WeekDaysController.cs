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
    public class WeekDaysController : Controller
    {
        private readonly BalmoozdaqContext _context;

        public WeekDaysController(BalmoozdaqContext context)
        {
            _context = context;
        }

        // GET: WeekDays
        public async Task<IActionResult> Index()
        {
            return View(await _context.WeekDays.ToListAsync());
        }

        // GET: WeekDays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weekDay = await _context.WeekDays
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weekDay == null)
            {
                return NotFound();
            }

            return View(weekDay);
        }

        // GET: WeekDays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WeekDays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DayName")] WeekDay weekDay)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weekDay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(weekDay);
        }

        // GET: WeekDays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weekDay = await _context.WeekDays.FindAsync(id);
            if (weekDay == null)
            {
                return NotFound();
            }
            return View(weekDay);
        }

        // POST: WeekDays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DayName")] WeekDay weekDay)
        {
            if (id != weekDay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weekDay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeekDayExists(weekDay.Id))
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
            return View(weekDay);
        }

        // GET: WeekDays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weekDay = await _context.WeekDays
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weekDay == null)
            {
                return NotFound();
            }

            return View(weekDay);
        }

        // POST: WeekDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weekDay = await _context.WeekDays.FindAsync(id);
            _context.WeekDays.Remove(weekDay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeekDayExists(int id)
        {
            return _context.WeekDays.Any(e => e.Id == id);
        }
    }
}
