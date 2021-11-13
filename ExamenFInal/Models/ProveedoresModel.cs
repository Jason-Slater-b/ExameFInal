using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFInal.Models
{
    public class ProveedoresModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "IdProveedor")]
        public int IdProveedor { get; set; }


        [Required(ErrorMessage = "El campo nombre del proveedor es obligatorio")]
        [Column(TypeName = "varchar(35)")]
        [Display(Name = "Proveedor")]
        public string Proveedor { get; set; }

        [Required(ErrorMessage = "El campo de direccion es obligatorio")]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "direcion")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo telefono es obligatorio")]
        [Column(TypeName = "varchar(15)")]
        [Display(Name = "telefono")]
        public string telefono { get; set; }

        [Required(ErrorMessage = "El campo de correo es obligatorio")]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "correo")]
        public string correo { get; set; }

        [Column(TypeName = "varchar(3)")]
        [Display(Name = "Estado de proveedor")]
        public string EstadoProveedor { get; set; } = "ACT";

    }
}
