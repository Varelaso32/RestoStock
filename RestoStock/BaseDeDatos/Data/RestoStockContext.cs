using Microsoft.EntityFrameworkCore;
using RestoStock.Models;

namespace RestoStock.BaseDeDatos.Data
{
    public class RestoStockContext: DbContext
    {

        public RestoStockContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<DetallesPlato> DetallesPlatos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Plato> Platos { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<User> User { get; set; }

    }
}
