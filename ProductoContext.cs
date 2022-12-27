using Microsoft.EntityFrameworkCore;
using prueba_kame.Models;

namespace prueba_kame

{
    public class ProductoContext : DbContext
    {
        public DbSet<Producto> Productos { get; set; }

        public ProductoContext(DbContextOptions<ProductoContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Producto> productosInit = new List<Producto>();
            productosInit.Add(new Producto() { ProductoId = 1, Nombre = "SAMSUNG 970 EVO Plus SSD 2TB", Detalle = "NVMe M.2 Unidad interna de estado sólido con tecnología V-NAND, almacenamiento y expansión de memoria para juegos", Precio = 600000 });
            productosInit.Add(new Producto() { ProductoId = 2, Nombre = "SSD M.2 Samsung 980 PRO 1TB", Detalle = "PCIe NVMe Gen4 interno para juegos (MZ-V8P1T0B)", Precio = 600000 });
            productosInit.Add(new Producto() { ProductoId = 3, Nombre = "SSD M.2 Samsung 980 PRO 1TB", Detalle = "PCIe NVMe Gen4 interno para juegos (MZ-V8P1T0B)", Precio = 600000 });

            modelBuilder.Entity<Producto>(producto =>
            {
                producto.ToTable("Producto");
                producto.HasKey(p => p.ProductoId);
                producto.Property(p => p.Nombre).IsRequired().HasMaxLength(100);
                producto.Property(p => p.Detalle).IsRequired().HasMaxLength(300);
                producto.Property(p => p.Precio).IsRequired();

                producto.HasData(productosInit);

            });

        }

    }



}
