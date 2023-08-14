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
    public class PedidosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PedidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pedidos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Pedidos.Include(p => p.Producto);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Pedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            ViewData["ProductoId"] = new SelectList(_context.Productos, "CodigoProducto", "CodigoProducto");
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductoId,CantidadDePedido,PrecioPorUnidadDeMedida,FechaEntrega,PersonaQueEntrega,PersonaQueRecibe,EmpresaQueRecibe,NumeroFactura")] Pedido pedido)
        {
            ModelState.Remove("Producto.NombreProducto");

            if (ModelState.IsValid)
            {
                Producto? producto = _context.Productos.FirstOrDefault(p => p.CodigoProducto == pedido.ProductoId);
                if(producto != null)
                {
                    pedido.Producto = producto;

                    if( pedido.Producto.CantidadMaxima >= (pedido.Producto.CantidadActual + pedido.CantidadDePedido))
                    {
                        _context.Add(pedido);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(nameof(pedido.CantidadDePedido), "El pedido supera la cantidad maxima de inventario.");
                    }
                }
            }
            ViewData["ProductoId"] = new SelectList(_context.Productos, "CodigoProducto", "CodigoProducto", pedido.ProductoId);
            return View(pedido);
        }

        // GET: Pedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["ProductoId"] = new SelectList(_context.Productos, "CodigoProducto", "CodigoProducto", pedido.ProductoId);
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductoId,CantidadDePedido,PrecioPorUnidadDeMedida,FechaEntrega,PersonaQueEntrega,PersonaQueRecibe,EmpresaQueRecibe,NumeroFactura, Entregado")] Pedido pedido)
        {
            if (id != pedido.Id)
            {
                return NotFound();
            }

            ModelState.Remove("Producto.NombreProducto");


            if (ModelState.IsValid)
            {
                try
                {
                    Producto? producto = _context.Productos.FirstOrDefault(p => p.CodigoProducto == pedido.ProductoId);
                    if(producto != null)
                    {
                        pedido.Producto = producto;

                        if (pedido.Entregado)
                        {
                            pedido.Producto.CantidadActual += pedido.CantidadDePedido;
                        }
                        _context.Update(pedido);
                        await _context.SaveChangesAsync();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.Id))
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
            ViewData["ProductoId"] = new SelectList(_context.Productos, "CodigoProducto", "CodigoProducto", pedido.ProductoId);
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Pedidos == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Producto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Pedidos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Pedidos'  is null.");
            }
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Pedidos/ConfirmRequest/5
        public async Task<IActionResult> ConfirmRequest(int id)
		{
			if (_context.Pedidos == null)
			{
				return Problem("Entity set 'ApplicationDbContext.Pedidos'  is null.");
			}

			Pedido? pedido = _context.Pedidos.Include(p => p.Producto).FirstOrDefault(p => p.Id == id);
			if (pedido != null)
			{

                int cantidadAIngresar = pedido.CantidadDePedido;
                pedido.Producto.CantidadActual += cantidadAIngresar;
                pedido.Entregado = true;
                _context.Update(pedido);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool PedidoExists(int id)
        {
          return (_context.Pedidos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
