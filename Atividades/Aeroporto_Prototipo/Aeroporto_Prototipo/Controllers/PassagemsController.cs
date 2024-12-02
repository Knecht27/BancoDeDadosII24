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
    public class PassagemsController : Controller
    {
        private readonly AeroportoContext _context;

        public PassagemsController(AeroportoContext context)
        {
            _context = context;
        }

        // GET: Passagems
        public async Task<IActionResult> Index()
        {
            var aeroportoContext = _context.Passagems.Include(p => p.AeroportoDecolagemNavigation).Include(p => p.AeroportoPousoNavigation).Include(p => p.ClientePassagemNavigation).Include(p => p.PoltronaNavigation).Include(p => p.VooNumNavigation);
            return View(await aeroportoContext.ToListAsync());
        }

        // GET: Passagems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passagem = await _context.Passagems
                .Include(p => p.AeroportoDecolagemNavigation)
                .Include(p => p.AeroportoPousoNavigation)
                .Include(p => p.ClientePassagemNavigation)
                .Include(p => p.PoltronaNavigation)
                .Include(p => p.VooNumNavigation)
                .FirstOrDefaultAsync(m => m.IdPassagem == id);
            if (passagem == null)
            {
                return NotFound();
            }

            return View(passagem);
        }

        // GET: Passagems/Create
        public IActionResult Create()
        {
            ViewData["AeroportoDecolagem"] = new SelectList(_context.Aeroportos, "IdAeroporto", "IdAeroporto");
            ViewData["AeroportoPouso"] = new SelectList(_context.Aeroportos, "IdAeroporto", "IdAeroporto");
            ViewData["ClientePassagem"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente");
            ViewData["Poltrona"] = new SelectList(_context.Poltronas, "IdPoltrona", "IdPoltrona");
            ViewData["VooNum"] = new SelectList(_context.Voos, "IdVoo", "IdVoo");
            return View();
        }

        // POST: Passagems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPassagem,NumeroPassagem,ClientePassagem,VooNum,Poltrona,AeroportoDecolagem,AeroportoPouso")] Passagem passagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AeroportoDecolagem"] = new SelectList(_context.Aeroportos, "IdAeroporto", "IdAeroporto", passagem.AeroportoDecolagem);
            ViewData["AeroportoPouso"] = new SelectList(_context.Aeroportos, "IdAeroporto", "IdAeroporto", passagem.AeroportoPouso);
            ViewData["ClientePassagem"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", passagem.ClientePassagem);
            ViewData["Poltrona"] = new SelectList(_context.Poltronas, "IdPoltrona", "IdPoltrona", passagem.Poltrona);
            ViewData["VooNum"] = new SelectList(_context.Voos, "IdVoo", "IdVoo", passagem.VooNum);
            return View(passagem);
        }

        // GET: Passagems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passagem = await _context.Passagems.FindAsync(id);
            if (passagem == null)
            {
                return NotFound();
            }
            ViewData["AeroportoDecolagem"] = new SelectList(_context.Aeroportos, "IdAeroporto", "IdAeroporto", passagem.AeroportoDecolagem);
            ViewData["AeroportoPouso"] = new SelectList(_context.Aeroportos, "IdAeroporto", "IdAeroporto", passagem.AeroportoPouso);
            ViewData["ClientePassagem"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", passagem.ClientePassagem);
            ViewData["Poltrona"] = new SelectList(_context.Poltronas, "IdPoltrona", "IdPoltrona", passagem.Poltrona);
            ViewData["VooNum"] = new SelectList(_context.Voos, "IdVoo", "IdVoo", passagem.VooNum);
            return View(passagem);
        }

        // POST: Passagems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPassagem,NumeroPassagem,ClientePassagem,VooNum,Poltrona,AeroportoDecolagem,AeroportoPouso")] Passagem passagem)
        {
            if (id != passagem.IdPassagem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassagemExists(passagem.IdPassagem))
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
            ViewData["AeroportoDecolagem"] = new SelectList(_context.Aeroportos, "IdAeroporto", "IdAeroporto", passagem.AeroportoDecolagem);
            ViewData["AeroportoPouso"] = new SelectList(_context.Aeroportos, "IdAeroporto", "IdAeroporto", passagem.AeroportoPouso);
            ViewData["ClientePassagem"] = new SelectList(_context.Clientes, "IdCliente", "IdCliente", passagem.ClientePassagem);
            ViewData["Poltrona"] = new SelectList(_context.Poltronas, "IdPoltrona", "IdPoltrona", passagem.Poltrona);
            ViewData["VooNum"] = new SelectList(_context.Voos, "IdVoo", "IdVoo", passagem.VooNum);
            return View(passagem);
        }

        // GET: Passagems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passagem = await _context.Passagems
                .Include(p => p.AeroportoDecolagemNavigation)
                .Include(p => p.AeroportoPousoNavigation)
                .Include(p => p.ClientePassagemNavigation)
                .Include(p => p.PoltronaNavigation)
                .Include(p => p.VooNumNavigation)
                .FirstOrDefaultAsync(m => m.IdPassagem == id);
            if (passagem == null)
            {
                return NotFound();
            }

            return View(passagem);
        }

        // POST: Passagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var passagem = await _context.Passagems.FindAsync(id);
            if (passagem != null)
            {
                _context.Passagems.Remove(passagem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassagemExists(int id)
        {
            return _context.Passagems.Any(e => e.IdPassagem == id);
        }
    }
}
