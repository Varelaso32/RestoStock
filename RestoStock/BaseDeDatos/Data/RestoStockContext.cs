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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación entre DetallesPlatos y Ingredientes
            modelBuilder.Entity<DetallesPlato>()
                .HasOne(dp => dp.Ingrediente) // DetallesPlato tiene una relación con Ingrediente
                .WithMany(i => i.DetallesPlatos) // Ingrediente puede tener muchos DetallesPlatos
                .HasForeignKey(dp => dp.FkIngredientes) // La clave foránea está en DetallesPlatos
                .OnDelete(DeleteBehavior.Cascade); // Si se elimina un Ingrediente, se eliminan los DetallesPlatos relacionados

            // Relación entre DetallesPlatos y Platos
            modelBuilder.Entity<DetallesPlato>()
                .HasOne(dp => dp.Plato) // DetallesPlato tiene una relación con Plato
                .WithMany(p => p.DetallesPlatos) // Plato puede tener muchos DetallesPlatos
                .HasForeignKey(dp => dp.FkPlato) // La clave foránea está en DetallesPlatos
                .OnDelete(DeleteBehavior.Cascade); // Si se elimina un Plato, se eliminan los DetallesPlatos relacionados
        }

    }


}
