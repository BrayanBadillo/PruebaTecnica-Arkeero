using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Productos.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InsertDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Herramientas Electricas" },
                    { 2, "Herramientas Manuales" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedAt", "Description", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 3, 11, 12, 54, 15, 693, DateTimeKind.Utc).AddTicks(7886), "Taladro de 500W de 1/2\" con velocidad variable de 0 - 3000 RPM, incluye Mango, Guía y llave para sacar broca, Tutoriales sobre el buen uso de la herramienta. ", "Taladro 1/2 500W Beta", 139500m, 10 },
                    { 2, 1, new DateTime(2024, 3, 11, 12, 54, 15, 693, DateTimeKind.Utc).AddTicks(7890), "Taladro de 420W de 1/4\" con velocidad variable de 0 - 4200 RPM, incluye Catálogo, Llave para mandril. Tutoriales sobre el buen uso de la herramienta. ", "Taladro 1/4 420W Avinci", 122100m, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}