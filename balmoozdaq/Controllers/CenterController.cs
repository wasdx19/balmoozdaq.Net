using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using balmoozdaq.Data;
using balmoozdaq.Models;
using balmoozdaq.Services;

namespace balmoozdaq.Controllers
{
    public class CenterController : Controller
    {
        private readonly CenterService _service;

        public CenterController(CenterService service)
        {
            _service = service;
        }

        // GET: Center
        public async Task<IActionResult> Index()
        {
            return View(await _service.GetCenter());
        }

        // GET: Center/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var center = await _service.DetailsCenter(id);
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
                await _service.AddAndSave(center);
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

            var center = await _service.DetailsCenter(id);
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
                    await _service.Update(center);
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

            var center = await _service.DetailsCenter(id);
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
            var center = await _service.DetailsCenter(id);
            await _service.Delete(center);
            return RedirectToAction(nameof(Index));
        }

        private bool CenterExists(int id)
        {
            return _service.CenterExis(id);
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
