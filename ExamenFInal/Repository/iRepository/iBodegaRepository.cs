using ExamenFInal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFInal.Repository.iRepository
{
    interface iBodegaRepository
    {
        ICollection<BodegaModel> GetBodegaModels();  //Obtengo un listado completo de todas las personas
        BodegaModel GetBodega(int nIdBodega); //Obtengo a la persona según el código que le envíe.
        bool CrearBodega(BodegaModel bodega); //Creo un registro en la base de datos con inf. de la persona
        bool ActualizarBodega(BodegaModel bodega);//Actualiza un registro en la base de datos.
        bool BorrarBodega(BodegaModel bodega);//Borra un registro en la tabla. DEBE CONSIDERAR QUE DEBEMOS REALIZAR BORRADO LÓGICO A TRAVÉS DE UN ESTADO DEL REGISTRO
        bool GuardarBodega(); //Guardar los datos en la BD.

    }
}
