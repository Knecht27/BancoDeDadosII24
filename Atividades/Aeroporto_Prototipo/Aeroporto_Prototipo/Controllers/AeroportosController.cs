using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aeroporto_Prototipo.Models;

namespace Aeroporto_Prototipo.Controllers
{
    public class AeroportosController : Controller
    {
        private readonly AeroportoContext _context;

        public AeroportosController(AeroportoContext context)
        {
            _context = context;
        }

        // GET: Aeroportos
        public async Task<IActionResult> Index()
        {
            var aeroportoContext = _context.Aeroportos.Include(a => a.CidadeNavigation);
            return View(await aeroportoContext.ToListAsync());
        }

        // GET: Aeroportos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeroporto = await _context.Aeroportos
                .Include(a => a.CidadeNavigation)
                .FirstOrDefaultAsync(m => m.IdAeroporto == id);
            if (aeroporto == null)
            {
                return NotFound();
            }

            return View(aeroporto);
        }

        // GET: Aeroportos/Create
        public IActionResult Create()
        {
            ViewData["Cidade"] = new SelectList(_context.Cidades, "IdCidade", "IdCidade");
            return View();
        }

        // POST: Aeroportos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAeroporto,Nome,Cidade,Cnpj,Sigla")] Aeroporto aeroporto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aeroporto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cidade"] = new SelectList(_context.Cidades, "IdCidade", "IdCidade", aeroporto.Cidade);
            return View(aeroporto);
        }

        // GET: Aeroportos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeroporto = await _context.Aeroportos.FindAsync(id);
            if (aeroporto == null)
            {
                return NotFound();
            }
            ViewData["Cidade"] = new SelectList(_context.Cidades, "IdCidade", "IdCidade", aeroporto.Cidade);
            return View(aeroporto);
        }

        // POST: Aeroportos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAeroporto,Nome,Cidade,Cnpj,Sigla")] Aeroporto aeroporto)
        {
            if (id != aeroporto.IdAeroporto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aeroporto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AeroportoExists(aeroporto.IdAeroporto))
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
            ViewData["Cidade"] = new SelectList(_context.Cidades, "IdCidade", "IdCidade", aeroporto.Cidade);
            return View(aeroporto);
        }

        // GET: Aeroportos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeroporto = await _context.Aeroportos
                .Include(a => a.CidadeNavigation)
                .FirstOrDefaultAsync(m => m.IdAeroporto == id);
            if (aeroporto == null)
            {
                return NotFound();
            }

            return View(aeroporto);
        }

        // POST: Aeroportos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aeroporto = await _context.Aeroportos.FindAsync(id);
            if (aeroporto != null)
            {
                _context.Aeroportos.Remove(aeroporto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AeroportoExists(int id)
        {
            return _context.Aeroportos.Any(e => e.IdAeroporto == id);
        }
    }
}
