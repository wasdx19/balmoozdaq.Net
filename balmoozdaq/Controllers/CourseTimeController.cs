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
    public class CourseTimeController : Controller
    {
        private readonly BalmoozdaqContext _context;

        public CourseTimeController(BalmoozdaqContext context)
        {
            _context = context;
        }

        // GET: CourseTime
        public async Task<IActionResult> Index()
        {
            var balmoozdaqContext = _context.CourseTime.Include(c => c.Course).Include(c => c.Weekday);
            return View(await balmoozdaqContext.ToListAsync());
        }

        // GET: CourseTime/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseTime = await _context.CourseTime
                .Include(c => c.Course)
                .Include(c => c.Weekday)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseTime == null)
            {
                return NotFound();
            }

            return View(courseTime);
        }

        // GET: CourseTime/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id");
            ViewData["WeekdayId"] = new SelectList(_context.Weekday, "Id", "Id");
            return View();
        }

        // POST: CourseTime/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartTime,EndTime,WeekdayId,CourseId")] CourseTime courseTime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseTime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", courseTime.CourseId);
            ViewData["WeekdayId"] = new SelectList(_context.Weekday, "Id", "Id", courseTime.WeekdayId);
            return View(courseTime);
        }

        // GET: CourseTime/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseTime = await _context.CourseTime.FindAsync(id);
            if (courseTime == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", courseTime.CourseId);
            ViewData["WeekdayId"] = new SelectList(_context.Weekday, "Id", "Id", courseTime.WeekdayId);
            return View(courseTime);
        }

        // POST: CourseTime/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartTime,EndTime,WeekdayId,CourseId")] CourseTime courseTime)
        {
            if (id != courseTime.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(courseTime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseTimeExists(courseTime.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Course, "Id", "Id", courseTime.CourseId);
            ViewData["WeekdayId"] = new SelectList(_context.Weekday, "Id", "Id", courseTime.WeekdayId);
            return View(courseTime);
        }

        // GET: CourseTime/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseTime = await _context.CourseTime
                .Include(c => c.Course)
                .Include(c => c.Weekday)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseTime == null)
            {
                return NotFound();
            }

            return View(courseTime);
        }

        // POST: CourseTime/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseTime = await _context.CourseTime.FindAsync(id);
            _context.CourseTime.Remove(courseTime);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseTimeExists(int id)
        {
            return _context.CourseTime.Any(e => e.Id == id);
        }
    }
}
