using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFInal.Models.DTOs
{
    public class ProductoSaveDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="ID Producto")]
        public int IdProducto { get; set; }
        public string IdProveedor { get; set; }
   
        public int cantidad { get; set; }
  
        public string Producto { get; set; }
  
        public string TipoProducto { get; set; }
    
        public string Descripcion { get; set; }

        public string Precio { get; set; }

        public string EstadoProducto { get; set; }
    }
}
