using ExamenFInal.Connection;
using ExamenFInal.Models;
using ExamenFInal.Repository.iRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFInal.Repository
{
    public class ProveedorRepository : iProveedorRepository
    {
        private readonly Conn _db;

        public ProveedorRepository (Conn db) { _db = db; }
        public bool ActualizarProveedor(ProveedoresModel proveedor)
        {
            _db.proveedoro.Update(proveedor);
            return GuardarProveedor();
        }

        public bool BorrarProveedor(ProveedoresModel proveedor)
        {
            _db.proveedoro.Remove(proveedor);
            return GuardarProveedor();
        }

        public bool CrearProveedor(ProveedoresModel proveedor)
        {
            _db.proveedoro.Add(proveedor);
            return GuardarProveedor();
        }

        public ProveedoresModel GetProveedor(int nIdProveedor)
        {
            return _db.proveedoro.FirstOrDefault(p => p.IdProveedor == nIdProveedor);
        }

        public ICollection<ProveedoresModel> GetProveedorModels()
        {
            return _db.proveedoro.OrderBy(p => p.IdProveedor).ToList();
        }

        public bool GuardarProveedor()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}
