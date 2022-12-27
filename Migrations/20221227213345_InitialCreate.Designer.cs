﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using prueba_kame;

#nullable disable

namespace pruebakame.Migrations
{
    [DbContext(typeof(ProductoContext))]
    [Migration("20221227213345_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("prueba_kame.Models.Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductoId"));

                    b.Property<string>("Detalle")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Precio")
                        .HasColumnType("int");

                    b.HasKey("ProductoId");

                    b.ToTable("Producto", (string)null);

                    b.HasData(
                        new
                        {
                            ProductoId = 1,
                            Detalle = "NVMe M.2 Unidad interna de estado sólido con tecnología V-NAND, almacenamiento y expansión de memoria para juegos",
                            Nombre = "SAMSUNG 970 EVO Plus SSD 2TB",
                            Precio = 600000
                        },
                        new
                        {
                            ProductoId = 2,
                            Detalle = "PCIe NVMe Gen4 interno para juegos (MZ-V8P1T0B)",
                            Nombre = "SSD M.2 Samsung 980 PRO 1TB",
                            Precio = 600000
                        },
                        new
                        {
                            ProductoId = 3,
                            Detalle = "PCIe NVMe Gen4 interno para juegos (MZ-V8P1T0B)",
                            Nombre = "SSD M.2 Samsung 980 PRO 1TB",
                            Precio = 600000
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
