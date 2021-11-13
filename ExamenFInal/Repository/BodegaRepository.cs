using ExamenFInal.Connection;
using ExamenFInal.Models;
using ExamenFInal.Repository.iRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFInal.Repository
{
    public class BodegaRepository : iBodegaRepository
    {
        private readonly Conn _db;

        public BodegaRepository(Conn db) { _db = db; }
        public bool ActualizarBodega(BodegaModel bodega)
        {
            _db.Bodega.Update(bodega);
            return GuardarBodega();
        }

        public bool BorrarBodega(BodegaModel bodega)
        {
            _db.Bodega.Remove(bodega);
            return GuardarBodega();
        }

        public bool CrearBodega(BodegaModel bodega)
        {
            _db.Bodega.Add(bodega);
            return GuardarBodega();
        }

        public BodegaModel GetBodega(int nIdBodega)
        {
            return _db.Bodega.FirstOrDefault(p => p.IdBodega == nIdBodega);
        }

        public ICollection<BodegaModel> GetBodegaModels()
        {
            return _db.Bodega.OrderBy(p => p.IdBodega).ToList();
        }

        public bool GuardarBodega()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }
    }
}
