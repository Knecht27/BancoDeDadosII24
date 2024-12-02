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
    public class VoosController : Controller
    {
        private readonly AeroportoContext _context;

        public VoosController(AeroportoContext context)
        {
            _context = context;
        }

        // GET: Voos
        public async Task<IActionResult> Index()
        {
            var aeroportoContext = _context.Voos.Include(v => v.AeronaveNavigation).Include(v => v.DestinoNavigation).Include(v => v.PartidaNavigation);
            return View(await aeroportoContext.ToListAsync());
        }

        // GET: Voos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voo = await _context.Voos
                .Include(v => v.AeronaveNavigation)
                .Include(v => v.DestinoNavigation)
                .Include(v => v.PartidaNavigation)
                .FirstOrDefaultAsync(m => m.IdVoo == id);
            if (voo == null)
            {
                return NotFound();
            }

            return View(voo);
        }

        // GET: Voos/Create
        public IActionResult Create()
        {
            ViewData["Aeronave"] = new SelectList(_context.Aeronaves, "IdAeronave", "IdAeronave");
            ViewData["Destino"] = new SelectList(_context.Aeroportos, "IdAeroporto", "IdAeroporto");
            ViewData["Partida"] = new SelectList(_context.Aeroportos, "IdAeroporto", "IdAeroporto");
            return View();
        }

        // POST: Voos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVoo,Partida,Destino,PrevistoDecolagem,PrevistoPouso,TempoDecolagem,TempoPouso,Aeronave")] Voo voo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Aeronave"] = new SelectList(_context.Aeronaves, "IdAeronave", "IdAeronave", voo.Aeronave);
            ViewData["Destino"] = new SelectList(_context.Aeroportos, "IdAeroporto", "IdAeroporto", voo.Destino);
            ViewData["Partida"] = new SelectList(_context.Aeroportos, "IdAeroporto", "IdAeroporto", voo.Partida);
            return View(voo);
        }

        // GET: Voos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voo = await _context.Voos.FindAsync(id);
            if (voo == null)
            {
                return NotFound();
            }
            ViewData["Aeronave"] = new SelectList(_context.Aeronaves, "IdAeronave", "IdAeronave", voo.Aeronave);
            ViewData["Destino"] = new SelectList(_context.Aeroportos, "IdAeroporto", "IdAeroporto", voo.Destino);
            ViewData["Partida"] = new SelectList(_context.Aeroportos, "IdAeroporto", "IdAeroporto", voo.Partida);
            return View(voo);
        }

        // POST: Voos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVoo,Partida,Destino,PrevistoDecolagem,PrevistoPouso,TempoDecolagem,TempoPouso,Aeronave")] Voo voo)
        {
            if (id != voo.IdVoo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VooExists(voo.IdVoo))
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
            ViewData["Aeronave"] = new SelectList(_context.Aeronaves, "IdAeronave", "IdAeronave", voo.Aeronave);
            ViewData["Destino"] = new SelectList(_context.Aeroportos, "IdAeroporto", "IdAeroporto", voo.Destino);
            ViewData["Partida"] = new SelectList(_context.Aeroportos, "IdAeroporto", "IdAeroporto", voo.Partida);
            return View(voo);
        }

        // GET: Voos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voo = await _context.Voos
                .Include(v => v.AeronaveNavigation)
                .Include(v => v.DestinoNavigation)
                .Include(v => v.PartidaNavigation)
                .FirstOrDefaultAsync(m => m.IdVoo == id);
            if (voo == null)
            {
                return NotFound();
            }

            return View(voo);
        }

        // POST: Voos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voo = await _context.Voos.FindAsync(id);
            if (voo != null)
            {
                _context.Voos.Remove(voo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VooExists(int id)
        {
            return _context.Voos.Any(e => e.IdVoo == id);
        }
    }
}
