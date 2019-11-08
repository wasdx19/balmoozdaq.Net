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
    public class CourseTimesController : Controller
    {
        private readonly BalmoozdaqContext _context;

        public CourseTimesController(BalmoozdaqContext context)
        {
            _context = context;
        }

        // GET: CourseTimes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CourseTimes.ToListAsync());
        }

        // GET: CourseTimes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseTime = await _context.CourseTimes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseTime == null)
            {
                return NotFound();
            }

            return View(courseTime);
        }

        // GET: CourseTimes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CourseTimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CourseStartTime,CourseEndTime")] CourseTime courseTime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(courseTime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(courseTime);
        }

        // GET: CourseTimes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseTime = await _context.CourseTimes.FindAsync(id);
            if (courseTime == null)
            {
                return NotFound();
            }
            return View(courseTime);
        }

        // POST: CourseTimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseStartTime,CourseEndTime")] CourseTime courseTime)
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
            return View(courseTime);
        }

        // GET: CourseTimes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseTime = await _context.CourseTimes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (courseTime == null)
            {
                return NotFound();
            }

            return View(courseTime);
        }

        // POST: CourseTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var courseTime = await _context.CourseTimes.FindAsync(id);
            _context.CourseTimes.Remove(courseTime);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseTimeExists(int id)
        {
            return _context.CourseTimes.Any(e => e.Id == id);
        }
    }
}
