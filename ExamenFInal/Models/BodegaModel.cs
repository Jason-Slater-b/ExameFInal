using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFInal.Models
{
    public class BodegaModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //Para genear un auto incrementable en la base de datos (secuencial)
        [Display(Name = "Codigo Bodega")]
        public int IdBodega { get; set; }

        [ForeignKey("Producto")]
        public int IdProducto { get; set; }
        //obejto de la llave foranea
        [ForeignKey("IdProducto")]
        public virtual ProductoModel Producto { get; set; }

        [Required(ErrorMessage = "El campo Cantidad  Producto es obligatorio")]
        [Column(TypeName = "int")]
        [Display(Name = "cantidad Producto")]
        public int cantidadProducto { get; set; }

        [Required(ErrorMessage = "El campo nombre de la bodega es obligatorio")]                         //Para hacer obligatorio en campo en el formulario
        [Column(TypeName = "varchar(35)")]  //Defino el tipo de dato que utilizará en base de datos
        [Display(Name = "Bodega")] //Personalizar la etiqueta en el formulario
        public string NombreBodega { get; set; }

        [Required(ErrorMessage = "El campo direccion bodega es obligatorio")]
        [Column(TypeName = "varchar(35)")]
        [Display(Name = "Direccion Bodega")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "El campo telefono es obligatorio")]
        [Column(TypeName = "varchar(35)")]
        [Display(Name = "telefono")]
        public string telefono{ get; set; }

        [Required(ErrorMessage = "El campo de correo es obligatorio")]
        [Column(TypeName = "varchar(35)")]
        [Display(Name = "correo")]
        public string correo { get; set; }

    }
}
