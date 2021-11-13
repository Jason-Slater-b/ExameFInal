using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFInal.Models.DTOs
{
    public class ProductoDto
    {
        [Display(Name = "IdProveedor")]
        public string IdProveedor { get;  set; }

        [Display(Name ="cantidad")]
        public int cantidad { get; set; }

        [Display(Name ="Producto")]
        public string Producto { get; set; }

        [Display(Name = "Tipo Producto")]
        public string TipoProducto { get; set; }

        [Display(Name ="Descripcion")]
        public string Descripcion { get; set; }

        [Display(Name ="Precio")]
        public string Precio { get; set; }

        [Display(Name ="Estado Producto")]
        public string EstadoProducto { get; set; }
    }
}
