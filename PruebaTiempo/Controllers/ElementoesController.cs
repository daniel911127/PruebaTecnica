using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PruebaTiempo.Models;

namespace PruebaTiempo.Controllers
{
    public class ElementoesController : Controller
    {
        private readonly PRUEBAContext _context;

        public ElementoesController(PRUEBAContext context)
        {
            _context = context;
        }

        // GET: Elementoes
        public async Task<IActionResult> Index()
        {
              return _context.Elementos != null ? 
                          View(await _context.Elementos.ToListAsync()) :
                          Problem("Entity set 'PRUEBAContext.Elementos'  is null.");
        }

        // GET: Elementoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Elementos == null)
            {
                return NotFound();
            }

            var elemento = await _context.Elementos
                .FirstOrDefaultAsync(m => m.ElementId == id);
            if (elemento == null)
            {
                return NotFound();
            }

            return View(elemento);
        }

        // GET: Elementoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Elementoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ElementId,Nombre")] Elemento elemento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(elemento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(elemento);
        }

        // GET: Elementoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Elementos == null)
            {
                return NotFound();
            }

            var elemento = await _context.Elementos.FindAsync(id);
            if (elemento == null)
            {
                return NotFound();
            }
            return View(elemento);
        }

        // POST: Elementoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ElementId,Nombre")] Elemento elemento)
        {
            if (id != elemento.ElementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(elemento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElementoExists(elemento.ElementId))
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
            return View(elemento);
        }

        // GET: Elementoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Elementos == null)
            {
                return NotFound();
            }

            var elemento = await _context.Elementos
                .FirstOrDefaultAsync(m => m.ElementId == id);
            if (elemento == null)
            {
                return NotFound();
            }

            return View(elemento);
        }

        // POST: Elementoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Elementos == null)
            {
                return Problem("Entity set 'PRUEBAContext.Elementos'  is null.");
            }
            var elemento = await _context.Elementos.FindAsync(id);
            if (elemento != null)
            {
                _context.Elementos.Remove(elemento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ElementoExists(int id)
        {
          return (_context.Elementos?.Any(e => e.ElementId == id)).GetValueOrDefault();
        }
    }
}
