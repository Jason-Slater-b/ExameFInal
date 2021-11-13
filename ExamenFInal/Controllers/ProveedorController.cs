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
    public class ProveedorController : Controller
    {
        private readonly ILogger<ProveedorController> _logger;
        private readonly Conn _context;

        public ProveedorController(Conn context)
        {
            _context = context;
        }
        public IActionResult Proveedorr()
        {
            return View();
        }
        public async Task<IActionResult> Indexproveedor()
        {
            return View(await _context.proveedoro.ToListAsync());  //Lista registros de la tabla tbl_personas.
        }
        [HttpPost]
        public async Task<IActionResult> Proveedorr([Bind("IdProveedor,Proveedor,Direccion,Telefono,Corre,EstadoProveedor")] ProveedoresModel proveedormodel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proveedormodel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Indexproveedor));
            }
            return View(proveedormodel);
        }
        [HttpGet]
        public async Task<IActionResult> ConsultaProveedor(string id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var Datos = await _context.proveedoro
                .FirstOrDefaultAsync(a => a.IdProveedor == int.Parse(id));
            return View(Datos);
        }

        public async Task<IActionResult> EditaPersona(string id)
        {
            int nIdProveedor;
            if (id == null)
            {
                return NotFound();
            }

            nIdProveedor = int.Parse(id);
            var Datos = await _context.proveedoro.FindAsync(nIdProveedor);

            if (Datos == null)
            {
                return NotFound();
            }
            return View(Datos);
        }

        [HttpPost]
        public async Task<IActionResult> EditaProveedor(string id, [Bind("IdProveedor,Proveedor,Direccion,Telefono,Corre,EstadoProveedor")] ProveedoresModel proveedormodel)
        {

            if (id == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
                try
                {
                    _context.Update(proveedormodel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuscaProveedor(proveedormodel.IdProveedor.ToString()))
                    {
                        return NotFound();
                    }
                }
            return RedirectToAction(nameof(Index));
        }

        private bool BuscaProveedor(string id)
        {
            return _context.proveedoro.Any(e => e.IdProveedor.ToString() == id);
        }
    }
}
