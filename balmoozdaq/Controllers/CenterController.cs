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
    public class CenterController : Controller
    {
        private readonly BalmoozdaqContext _context;

        public CenterController(BalmoozdaqContext context)
        {
            _context = context;
        }

        // GET: Center
        public async Task<IActionResult> Index()
        {
            return View(await _context.Center.ToListAsync());
        }

        // GET: Center/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var center = await _context.Center
                .FirstOrDefaultAsync(m => m.Id == id);
            if (center == null)
            {
                return NotFound();
            }

            return View(center);
        }

        // GET: Center/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Center/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Phone,Address,Imgurl")] Center center)
        {
            if (ModelState.IsValid)
            {
                _context.Add(center);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(center);
        }

        // GET: Center/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var center = await _context.Center.FindAsync(id);
            if (center == null)
            {
                return NotFound();
            }
            return View(center);
        }

        // POST: Center/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Phone,Address,Imgurl")] Center center)
        {
            if (id != center.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(center);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CenterExists(center.Id))
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
            return View(center);
        }

        // GET: Center/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var center = await _context.Center
                .FirstOrDefaultAsync(m => m.Id == id);
            if (center == null)
            {
                return NotFound();
            }

            return View(center);
        }

        // POST: Center/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var center = await _context.Center.FindAsync(id);
            _context.Center.Remove(center);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CenterExists(int id)
        {
            return _context.Center.Any(e => e.Id == id);
        }

        //REMOTE VALIDATION
        [AcceptVerbs("GET", "POST")]
        public IActionResult CheckUrl(string imgurl)
        {
            if (!imgurl.Contains("//"))
            {
                return Json($"{imgurl} should contain //");
            }

            return Json(true);
        }
    }
}
