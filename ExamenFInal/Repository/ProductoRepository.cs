using ExamenFInal.Connection;
using ExamenFInal.Models;
using ExamenFInal.Repository.iRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFInal.Repository
{
    public class ProductoRepository : iProductoRepository
    {
        private readonly Conn _db;

        public ProductoRepository(Conn db) {
            _db = db;
        }

        public bool ActualizarProducto(ProductoModel producto)
        {
            _db.productos.Update(producto);
            return GuardarProducto();
        }

        public bool BorrarProducto(ProductoModel producto)
        {
            _db.productos.Remove(producto);
            return GuardarProducto();
        }

        public bool CrearProducto(ProductoModel producto)
        {
            _db.productos.Add(producto);
            return GuardarProducto();
        }

        public ProductoModel GetProducto(int nIdProdcuto)
        {
            return _db.productos.FirstOrDefault(p => p.IdProducto == nIdProdcuto);
        }

        public ICollection<ProductoModel> GetProductoModels()
        {
            return _db.productos.OrderBy(p => p.Producto).ToList();
        }

        public bool GuardarProducto()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}
