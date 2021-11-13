using ExamenFInal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFInal.Connection
{
    public class Conn:DbContext
    {
        public Conn(DbContextOptions<Conn> options) : base(options) { }
        public DbSet<ProductoModel> productos { get; set; }

        public DbSet<ProveedoresModel> proveedoro { get; set; }

        public DbSet<BodegaModel> Bodega { get; set; }

    }
}
