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
    public class EducationCentersController : Controller
    {
        private readonly BalmoozdaqContext _context;

        public EducationCentersController(BalmoozdaqContext context)
        {
            _context = context;
        }

        // GET: EducationCenters
        public async Task<IActionResult> Index()
        {
            var balmoozdaqContext = _context.EducationCenters.Include(e => e.User);
            return View(await balmoozdaqContext.ToListAsync());
        }

        // GET: EducationCenters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationCenter = await _context.EducationCenters
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (educationCenter == null)
            {
                return NotFound();
            }

            return View(educationCenter);
        }

        // GET: EducationCenters/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: EducationCenters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EduCenterName,EduCenterDesc,EduCenterPhone,EduCenterAddress,EduCenterImgUrl,UserId")] EducationCenter educationCenter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(educationCenter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", educationCenter.UserId);
            return View(educationCenter);
        }

        // GET: EducationCenters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationCenter = await _context.EducationCenters.FindAsync(id);
            if (educationCenter == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", educationCenter.UserId);
            return View(educationCenter);
        }

        // POST: EducationCenters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EduCenterName,EduCenterDesc,EduCenterPhone,EduCenterAddress,EduCenterImgUrl,UserId")] EducationCenter educationCenter)
        {
            if (id != educationCenter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(educationCenter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationCenterExists(educationCenter.Id))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", educationCenter.UserId);
            return View(educationCenter);
        }

        // GET: EducationCenters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationCenter = await _context.EducationCenters
                .Include(e => e.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (educationCenter == null)
            {
                return NotFound();
            }

            return View(educationCenter);
        }

        // POST: EducationCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var educationCenter = await _context.EducationCenters.FindAsync(id);
            _context.EducationCenters.Remove(educationCenter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducationCenterExists(int id)
        {
            return _context.EducationCenters.Any(e => e.Id == id);
        }
    }
}
