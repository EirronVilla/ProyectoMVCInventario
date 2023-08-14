using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto2_MVC_AaronVillalobosArguedas.Data;
using Proyecto2_MVC_AaronVillalobosArguedas.Models;

namespace Proyecto2_MVC_AaronVillalobosArguedas.Controllers
{
    public class HistorialController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HistorialController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Historial
        public async Task<IActionResult> Index()
        {
              return _context.Historial != null ? 
                          View(await _context.Historial.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Historial'  is null.");
        }

        // GET: Historial/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Historial == null)
            {
                return NotFound();
            }

            var historial = await _context.Historial
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historial == null)
            {
                return NotFound();
            }

            return View(historial);
        }

        // GET: Historial/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Historial/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,Mensaje,FechaRegistro")] Historial historial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(historial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(historial);
        }

        // GET: Historial/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Historial == null)
            {
                return NotFound();
            }

            var historial = await _context.Historial.FindAsync(id);
            if (historial == null)
            {
                return NotFound();
            }
            return View(historial);
        }

        // POST: Historial/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo,Mensaje,FechaRegistro")] Historial historial)
        {
            if (id != historial.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistorialExists(historial.Id))
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
            return View(historial);
        }

        // GET: Historial/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Historial == null)
            {
                return NotFound();
            }

            var historial = await _context.Historial
                .FirstOrDefaultAsync(m => m.Id == id);
            if (historial == null)
            {
                return NotFound();
            }

            return View(historial);
        }

        // POST: Historial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Historial == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Historial'  is null.");
            }
            var historial = await _context.Historial.FindAsync(id);
            if (historial != null)
            {
                _context.Historial.Remove(historial);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistorialExists(int id)
        {
          return (_context.Historial?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
