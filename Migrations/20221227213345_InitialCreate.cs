using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace pruebakame.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Detalle = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.ProductoId);
                });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "ProductoId", "Detalle", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "NVMe M.2 Unidad interna de estado sólido con tecnología V-NAND, almacenamiento y expansión de memoria para juegos", "SAMSUNG 970 EVO Plus SSD 2TB", 600000 },
                    { 2, "PCIe NVMe Gen4 interno para juegos (MZ-V8P1T0B)", "SSD M.2 Samsung 980 PRO 1TB", 600000 },
                    { 3, "PCIe NVMe Gen4 interno para juegos (MZ-V8P1T0B)", "SSD M.2 Samsung 980 PRO 1TB", 600000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producto");
        }
    }
}
