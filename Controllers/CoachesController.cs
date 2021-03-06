﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Models

{
    public class CoachesController : Controller
    {
        private readonly ProjectContext _context;

        public CoachesController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Coaches
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coaches.ToListAsync());
        }

        // GET: Coaches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coaches = await _context.Coaches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coaches == null)
            {
                return NotFound();
            }

            return View(coaches);
        }

        // GET: Coaches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coaches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CoachId,FirstName,LastName,Sertificate,HireDate")] Coaches coaches)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coaches);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coaches);
        }

        // GET: Coaches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coaches = await _context.Coaches.FindAsync(id);
            if (coaches == null)
            {
                return NotFound();
            }
            return View(coaches);
        }

        // POST: Coaches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CoachId,FirstName,LastName,Sertificate,HireDate")] Coaches coaches)
        {
            if (id != coaches.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coaches);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoachesExists(coaches.Id))
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
            return View(coaches);
        }

        // GET: Coaches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coaches = await _context.Coaches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coaches == null)
            {
                return NotFound();
            }

            return View(coaches);
        }

        // POST: Coaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coaches = await _context.Coaches.FindAsync(id);
            _context.Coaches.Remove(coaches);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoachesExists(int id)
        {
            return _context.Coaches.Any(e => e.Id == id);
        }
    }
}
