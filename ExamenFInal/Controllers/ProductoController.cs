using ExamenFInal.Connection;
using ExamenFInal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFInal.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ILogger<ProductoController> _Logger;
        private readonly Conn _Context;

        public ProductoController(Conn context)
        {
            _Context = context;
        }

        public IActionResult Productoss() {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            return View(await _Context.productos.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Prodcutoss([Bind("IdProducto, IdProveedor, Cantidad, Producto, TipoProducto, Descripcion, Precio, EstadoProducto")] ProductoModel productomodel)
        {
            if (ModelState.IsValid) {
                _Context.Add(productomodel);
                await _Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productomodel);
        }
        [HttpGet]
        public async Task<IActionResult> ConsultaProducto(string id)
        {
            if (id == null) {
                return NotFound();
            }
            var Datos = await _Context.productos
                .FirstOrDefaultAsync(a => a.IdProducto == int.Parse(id));
            return View(Datos);
        }

        public async Task<IActionResult>EditaProducto(string id)
        {
            int nIdProducto;
            if (id == null) {
                return NotFound();
            }
            nIdProducto = int.Parse(id);
            var Datos = await _Context.productos.FindAsync(nIdProducto);

            if (Datos == null) {
                return NotFound();
            }
            return View(Datos);
        }

        [HttpPost]
        public async Task<IActionResult> EditaProducto(string id,[Bind("IdProducto, IdProveedor, Cantidad, Producto, TipoProducto, Descripcion, Precio, EstadoProducto")] ProductoModel productomodel)
        {
            if (id == null) {
                return NotFound();
            }
            if (ModelState.IsValid)
                try
                {
                    _Context.Update(productomodel);
                    await _Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!BuscarProducto(productomodel.IdProducto.ToString()))
                    {
                        return NotFound();
                    }
                }
            return RedirectToAction(nameof(Index));
        }
        private bool BuscarProducto(string id) {
            return _Context.productos.Any(e => e.IdProducto.ToString() == id);
        }
    }

}
