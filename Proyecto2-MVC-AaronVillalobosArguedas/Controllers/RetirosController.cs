using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using Proyecto2_MVC_AaronVillalobosArguedas.Data;
using Proyecto2_MVC_AaronVillalobosArguedas.Models;

namespace Proyecto2_MVC_AaronVillalobosArguedas.Controllers
{
    public class RetirosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RetirosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Retiros
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Retiros.Include(r => r.Producto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Retiros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Retiros == null)
            {
                return NotFound();
            }

            var retiro = await _context.Retiros
                .Include(r => r.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (retiro == null)
            {
                return NotFound();
            }

            return View(retiro);
        }

        // GET: Retiros/Create
        public IActionResult Create()
        {
            ViewData["ProductoId"] = new SelectList(_context.Productos, "CodigoProducto", "CodigoProducto");
            return View();
        }

        // POST: Retiros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductoId,FechaEntrega,CantidadARetirar")] Retiro retiro)
        {
            Producto? producto = _context.Productos.FirstOrDefault(p => p.CodigoProducto == retiro.ProductoId);
            retiro.Producto = producto;
            ModelState.Remove("Producto.NombreProducto");
            if (ModelState.IsValid)
            {
                if(retiro.Producto != null)
                {
                    if(retiro.Producto.CantidadActual > retiro.CantidadARetirar)
                    {
						retiro.Producto.CantidadActual = retiro.Producto.CantidadActual - retiro.CantidadARetirar;
						_context.Add(retiro);
                        _context.Update(retiro.Producto);
					} else
                    {
                        ModelState.AddModelError(nameof(retiro.CantidadARetirar), "No hay suficientes existencias en el inventario para realizar el retiro.");
                    }

				}
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductoId"] = new SelectList(_context.Productos, "CodigoProducto", "CodigoProducto", retiro.ProductoId);
            return View(retiro);
        }

        // GET: Retiros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Retiros == null)
            {
                return NotFound();
            }

            var retiro = await _context.Retiros.FindAsync(id);
            if (retiro == null)
            {
                return NotFound();
            }
            ViewData["ProductoId"] = new SelectList(_context.Productos, "CodigoProducto", "CodigoProducto", retiro.ProductoId);
            return View(retiro);
        }

        // POST: Retiros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductoId,FechaEntrega,CantidadARetirar")] Retiro retiro)
        {
            if (id != retiro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(retiro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RetiroExists(retiro.Id))
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
            ViewData["ProductoId"] = new SelectList(_context.Productos, "CodigoProducto", "CodigoProducto", retiro.ProductoId);
            return View(retiro);
        }

        // GET: Retiros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Retiros == null)
            {
                return NotFound();
            }

            var retiro = await _context.Retiros
                .Include(r => r.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (retiro == null)
            {
                return NotFound();
            }

            return View(retiro);
        }

        // POST: Retiros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Retiros == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Retiros'  is null.");
            }
            var retiro = await _context.Retiros.FindAsync(id);
            if (retiro != null)
            {
                _context.Retiros.Remove(retiro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RetiroExists(int id)
        {
          return (_context.Retiros?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
