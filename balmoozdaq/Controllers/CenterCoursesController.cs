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
    public class CenterCoursesController : Controller
    {
        private readonly BalmoozdaqContext _context;

        public CenterCoursesController(BalmoozdaqContext context)
        {
            _context = context;
        }

        // GET: CenterCourses
        public async Task<IActionResult> Index()
        {
            var balmoozdaqContext = _context.CenterCourses.Include(c => c.Course).Include(c => c.EducationCenter).Include(c => c.User);
            return View(await balmoozdaqContext.ToListAsync());
        }

        // GET: CenterCourses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centerCourse = await _context.CenterCourses
                .Include(c => c.Course)
                .Include(c => c.EducationCenter)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.EduCenterId == id);
            if (centerCourse == null)
            {
                return NotFound();
            }

            return View(centerCourse);
        }

        // GET: CenterCourses/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id");
            ViewData["EduCenterId"] = new SelectList(_context.EducationCenters, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: CenterCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EduCenterId,CourseId,UserId,CenterCourseDesc")] CenterCourse centerCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(centerCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", centerCourse.CourseId);
            ViewData["EduCenterId"] = new SelectList(_context.EducationCenters, "Id", "Id", centerCourse.EduCenterId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", centerCourse.UserId);
            return View(centerCourse);
        }

        // GET: CenterCourses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centerCourse = await _context.CenterCourses.FindAsync(id);
            if (centerCourse == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", centerCourse.CourseId);
            ViewData["EduCenterId"] = new SelectList(_context.EducationCenters, "Id", "Id", centerCourse.EduCenterId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", centerCourse.UserId);
            return View(centerCourse);
        }

        // POST: CenterCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EduCenterId,CourseId,UserId,CenterCourseDesc")] CenterCourse centerCourse)
        {
            if (id != centerCourse.EduCenterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(centerCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CenterCourseExists(centerCourse.EduCenterId))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Id", centerCourse.CourseId);
            ViewData["EduCenterId"] = new SelectList(_context.EducationCenters, "Id", "Id", centerCourse.EduCenterId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", centerCourse.UserId);
            return View(centerCourse);
        }

        // GET: CenterCourses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centerCourse = await _context.CenterCourses
                .Include(c => c.Course)
                .Include(c => c.EducationCenter)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.EduCenterId == id);
            if (centerCourse == null)
            {
                return NotFound();
            }

            return View(centerCourse);
        }

        // POST: CenterCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var centerCourse = await _context.CenterCourses.FindAsync(id);
            _context.CenterCourses.Remove(centerCourse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CenterCourseExists(int id)
        {
            return _context.CenterCourses.Any(e => e.EduCenterId == id);
        }
    }
}
