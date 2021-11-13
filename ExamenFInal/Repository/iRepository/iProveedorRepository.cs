using ExamenFInal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFInal.Repository.iRepository
{
    interface iProveedorRepository
    {
        ICollection<ProveedoresModel> GetProveedorModels();
        ProveedoresModel GetProveedor(int nIdProveedor);
        bool CrearProveedor(ProveedoresModel proveedor);
        bool ActualizarProveedor(ProveedoresModel proveedor);
        bool BorrarProveedor(ProveedoresModel proveedor);
        bool GuardarProveedor();

    }
}
