using ExamenFInal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFInal.Repository.iRepository
{
    public interface iProductoRepository
    {
        ICollection<ProductoModel> GetProductoModels();

        ProductoModel GetProducto(int nIdProdcuto);

        bool CrearProducto(ProductoModel producto);
        bool ActualizarProducto(ProductoModel producto);
        bool BorrarProducto(ProductoModel producto);
        bool GuardarProducto();
    }
}
