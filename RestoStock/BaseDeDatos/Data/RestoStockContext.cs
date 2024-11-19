using Microsoft.EntityFrameworkCore;
using RestoStock.Models;

namespace RestoStock.BaseDeDatos.Data
{
    public class RestoStockContext : DbContext
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
<<<<<<< HEAD
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.Proveedor)
                .WithMany(b => b.Pedidos)
                .HasForeignKey(p => p.FkProveedor) 
                .HasConstraintName("FK_Pedidos_Proveedores_ProveedoresIdProveedor") 
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Pedido>()
                .Property(p => p.FkProveedor)
                .HasColumnName("ProveedoresIdProveedor"); 
        }


=======
            modelBuilder.Entity<DetallesPlato>()
                .HasOne(dp => dp.Ingrediente) 
                .WithMany(i => i.DetallesPlatos) 
                .HasForeignKey(dp => dp.FkIngredientes) 
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<DetallesPlato>()
                .HasOne(dp => dp.Plato) 
                .WithMany(p => p.DetallesPlatos) 
                .HasForeignKey(dp => dp.FkPlato) 
        }
>>>>>>> Develop

    }
}
