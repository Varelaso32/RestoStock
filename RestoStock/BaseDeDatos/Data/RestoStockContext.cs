using Microsoft.EntityFrameworkCore;
using RestoStock.Models;

namespace RestoStock.BaseDeDatos.Data
{
    public class RestoStockContext: DbContext
    {

        public RestoStockContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Ingredientes> Ingredientes { get; set; }
        public DbSet<DetallesPlatos> DetallesPlatos { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<Platos> Platos { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<User> User { get; set; }

    }
}
