﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aeroporto_Prototipo.Models;

namespace Aeroporto_Prototipo.Controllers
{
    public class PoltronasController : Controller
    {
        private readonly AeroportoContext _context;

        public PoltronasController(AeroportoContext context)
        {
            _context = context;
        }

        // GET: Poltronas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Poltronas.ToListAsync());
        }

        // GET: Poltronas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poltrona = await _context.Poltronas
                .FirstOrDefaultAsync(m => m.IdPoltrona == id);
            if (poltrona == null)
            {
                return NotFound();
            }

            return View(poltrona);
        }

        // GET: Poltronas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Poltronas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPoltrona,NumPoltrona,Ocupado")] Poltrona poltrona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poltrona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(poltrona);
        }

        // GET: Poltronas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poltrona = await _context.Poltronas.FindAsync(id);
            if (poltrona == null)
            {
                return NotFound();
            }
            return View(poltrona);
        }

        // POST: Poltronas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPoltrona,NumPoltrona,Ocupado")] Poltrona poltrona)
        {
            if (id != poltrona.IdPoltrona)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poltrona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoltronaExists(poltrona.IdPoltrona))
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
            return View(poltrona);
        }

        // GET: Poltronas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poltrona = await _context.Poltronas
                .FirstOrDefaultAsync(m => m.IdPoltrona == id);
            if (poltrona == null)
            {
                return NotFound();
            }

            return View(poltrona);
        }

        // POST: Poltronas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var poltrona = await _context.Poltronas.FindAsync(id);
            if (poltrona != null)
            {
                _context.Poltronas.Remove(poltrona);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoltronaExists(int id)
        {
            return _context.Poltronas.Any(e => e.IdPoltrona == id);
        }
    }
}
