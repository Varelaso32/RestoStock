﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestoStock.BaseDeDatos.Data;

#nullable disable

namespace RestoStock.Migrations
{
    [DbContext(typeof(RestoStockContext))]
    partial class RestoStockContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Pedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPedido"));

                    b.Property<string>("FechaPedido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FkProveedor")
                        .HasColumnType("int");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("IdPedido");

                    b.HasIndex("FkProveedor");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("RestoStock.Models.DetallesPlato", b =>
                {
                    b.Property<int>("IdDetalle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetalle"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("FkIngredientes")
                        .HasColumnType("int");

                    b.Property<int>("FkPlato")
                        .HasColumnType("int");

                    b.HasKey("IdDetalle");

                    b.HasIndex("FkIngredientes");

                    b.HasIndex("FkPlato");

                    b.ToTable("DetallesPlatos");
                });

            modelBuilder.Entity("RestoStock.Models.Ingrediente", b =>
                {
                    b.Property<int>("IdIngrediente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdIngrediente"));

                    b.Property<int>("CantidadDisponible")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrecioUnitario")
                        .HasColumnType("int");

                    b.Property<string>("UnidadMedida")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdIngrediente");

                    b.ToTable("Ingredientes");
                });

            modelBuilder.Entity("RestoStock.Models.Plato", b =>
                {
                    b.Property<int>("IdPlato")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPlato"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrecioVenta")
                        .HasColumnType("int");

                    b.HasKey("IdPlato");

                    b.ToTable("Platos");
                });

            modelBuilder.Entity("RestoStock.Models.Proveedor", b =>
                {
                    b.Property<int>("IdProveedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProveedor"));

                    b.Property<string>("Contacto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreEmpresa")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdProveedor");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("RestoStock.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Pedido", b =>
                {
                    b.HasOne("RestoStock.Models.Proveedor", "Proveedor")
                        .WithMany("Pedidos")
                        .HasForeignKey("FkProveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("RestoStock.Models.DetallesPlato", b =>
                {
                    b.HasOne("RestoStock.Models.Ingrediente", "Ingrediente")
                        .WithMany("DetallesPlatos")
                        .HasForeignKey("FkIngredientes")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestoStock.Models.Plato", "Plato")
                        .WithMany("DetallesPlatos")
                        .HasForeignKey("FkPlato")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ingrediente");

                    b.Navigation("Plato");
                });

            modelBuilder.Entity("RestoStock.Models.Ingrediente", b =>
                {
                    b.Navigation("DetallesPlatos");
                });

            modelBuilder.Entity("RestoStock.Models.Plato", b =>
                {
                    b.Navigation("DetallesPlatos");
                });

            modelBuilder.Entity("RestoStock.Models.Proveedor", b =>
                {
                    b.Navigation("Pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
