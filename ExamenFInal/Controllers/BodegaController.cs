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
    public class BodegaController : Controller
    {
        private readonly ILogger<BodegaController> _Logger;
        private readonly Conn _Context;

        public BodegaController(Conn context)
        {
            _Context = context;
        }

        public IActionResult bodegass ()
        {
            return View();
        }

        public async Task<IActionResult> IndexBodega()
        {
            return View(await _Context.Bodega.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> bodegass([Bind("IdBodega, IdProducto, cantidadProducto, NombreBodega, Direccion, telefono, correo")] BodegaModel bodegamodel)
        {
            if (ModelState.IsValid)
            {
                _Context.Add(bodegamodel);
                await _Context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexBodega));
            }
            return View(bodegamodel);
        }
        [HttpGet]
        public async Task<IActionResult> ConsultaBodega(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Datos = await _Context.Bodega
                .FirstOrDefaultAsync(a => a.IdBodega == int.Parse(id));
            return View(Datos);
        }

        public async Task<IActionResult> EditaBodega(string id)
        {
            int nIdBodega;
            if (id == null)
            {
                return NotFound();
            }
            nIdBodega = int.Parse(id);
            var Datos = await _Context.Bodega.FindAsync(nIdBodega);

            if (Datos == null)
            {
                return NotFound();
            }
            return View(Datos);
        }

        [HttpPost]
        public async Task<IActionResult> EditaBodega(string id, [Bind("IdBodega, IdProducto, cantidadProducto, NombreBodega, Direccion, telefono, correo")] BodegaModel bodegamodel)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
                try
                {
                    _Context.Update(bodegamodel);
                    await _Context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuscarProducto(bodegamodel.IdBodega.ToString()))
                    {
                        return NotFound();
                    }
                }
            return RedirectToAction(nameof(Index));
        }
        private bool BuscarProducto(string id)
        {
            return _Context.Bodega.Any(e => e.IdBodega.ToString() == id);
        }
    }
}
