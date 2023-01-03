﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using To_Do_List.Data;
using To_Do_List.Models;

namespace To_Do_List.Controllers
{
    public class To_DoController : Controller
    {
        private readonly To_Do_ListContext _context;

        public To_DoController(To_Do_ListContext context)
        {
            _context = context;
        }

        // GET: To_Do
        public async Task<IActionResult> Index(string searchString)
        {
            if (_context.To_Do == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            var movies = from m in _context.To_Do
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title!.Contains(searchString));
            }

            return View(await movies.ToListAsync());
        }

        // GET: To_Do/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.To_Do == null)
            {
                return NotFound();
            }

            var to_Do = await _context.To_Do
                .FirstOrDefaultAsync(m => m.Id == id);
            if (to_Do == null)
            {
                return NotFound();
            }

            return View(to_Do);
        }

        // GET: To_Do/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: To_Do/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,StartDate,EndDate,checkbox")] To_Do to_Do)
        {
            if (ModelState.IsValid)
            {
                _context.Add(to_Do);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(to_Do);
        }

        // GET: To_Do/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.To_Do == null)
            {
                return NotFound();
            }

            var to_Do = await _context.To_Do.FindAsync(id);
            if (to_Do == null)
            {
                return NotFound();
            }
            return View(to_Do);
        }

        // POST: To_Do/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,StartDate,EndDate,checkbox")] To_Do to_Do)
        {
            if (id != to_Do.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(to_Do);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!To_DoExists(to_Do.Id))
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
            return View(to_Do);
        }

        // GET: To_Do/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.To_Do == null)
            {
                return NotFound();
            }

            var to_Do = await _context.To_Do
                .FirstOrDefaultAsync(m => m.Id == id);
            if (to_Do == null)
            {
                return NotFound();
            }

            return View(to_Do);
        }

        // POST: To_Do/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.To_Do == null)
            {
                return Problem("Entity set 'To_Do_ListContext.To_Do'  is null.");
            }
            var to_Do = await _context.To_Do.FindAsync(id);
            if (to_Do != null)
            {
                _context.To_Do.Remove(to_Do);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool To_DoExists(int id)
        {
          return (_context.To_Do?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
