using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFInal.Models
{
    public class ProductoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="IdProducto")]
        public int IdProducto { get; set; }

        [ForeignKey("Proveedor")]
        public int IdProveedor { get; set; }
        //obejto de la llave foranea
        [ForeignKey("IdProveedor")]
        public virtual ProveedoresModel Proveedor { get; set; }

        [Required(ErrorMessage = "El campo Cantidad es obligatorio")]
        [Column(TypeName = "int")]
        [Display(Name = "cantidad")]
        public int cantidad { get; set; }

        [Required(ErrorMessage ="El campo nombre Producto es obligatorio")]
        [Column(TypeName="varchar(35)")]
        [Display(Name ="Producto")]
        public string Producto { get; set; }

        [Required(ErrorMessage = "El campo tipo de Producto es obligatorio")]
        [Column(TypeName = "varchar(35)")]
        [Display(Name = "TipoProducto")]
        public string TipoProducto { get; set; }

        [Required(ErrorMessage = "El campo de descripcion es obligatorio")]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo de precio de Producto es obligatorio")]
        [Column(TypeName = "float(35)")]
        [Display(Name = "Precio")]
        public float Precio { get; set; }

        [Column(TypeName = "varchar(3)")]
        [Display(Name = "Estado de Producto")]
        public string EstadoProducto { get; set; } = "ACT";
    }
}
