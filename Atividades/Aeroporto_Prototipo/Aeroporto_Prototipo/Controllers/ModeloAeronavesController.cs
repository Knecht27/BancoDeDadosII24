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
    public class ModeloAeronavesController : Controller
    {
        private readonly AeroportoContext _context;

        public ModeloAeronavesController(AeroportoContext context)
        {
            _context = context;
        }

        // GET: ModeloAeronaves
        public async Task<IActionResult> Index()
        {
            return View(await _context.ModeloAeronaves.ToListAsync());
        }

        // GET: ModeloAeronaves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloAeronave = await _context.ModeloAeronaves
                .FirstOrDefaultAsync(m => m.IdModelo == id);
            if (modeloAeronave == null)
            {
                return NotFound();
            }

            return View(modeloAeronave);
        }

        // GET: ModeloAeronaves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ModeloAeronaves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdModelo,NomeModelo,AnoModelo,CapacidadePoltronas,CapacidadeCombustivel")] ModeloAeronave modeloAeronave)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modeloAeronave);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modeloAeronave);
        }

        // GET: ModeloAeronaves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloAeronave = await _context.ModeloAeronaves.FindAsync(id);
            if (modeloAeronave == null)
            {
                return NotFound();
            }
            return View(modeloAeronave);
        }

        // POST: ModeloAeronaves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdModelo,NomeModelo,AnoModelo,CapacidadePoltronas,CapacidadeCombustivel")] ModeloAeronave modeloAeronave)
        {
            if (id != modeloAeronave.IdModelo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(modeloAeronave);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModeloAeronaveExists(modeloAeronave.IdModelo))
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
            return View(modeloAeronave);
        }

        // GET: ModeloAeronaves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var modeloAeronave = await _context.ModeloAeronaves
                .FirstOrDefaultAsync(m => m.IdModelo == id);
            if (modeloAeronave == null)
            {
                return NotFound();
            }

            return View(modeloAeronave);
        }

        // POST: ModeloAeronaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var modeloAeronave = await _context.ModeloAeronaves.FindAsync(id);
            if (modeloAeronave != null)
            {
                _context.ModeloAeronaves.Remove(modeloAeronave);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModeloAeronaveExists(int id)
        {
            return _context.ModeloAeronaves.Any(e => e.IdModelo == id);
        }
    }
}
