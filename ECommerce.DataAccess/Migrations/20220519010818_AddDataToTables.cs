using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.DataAccess.Migrations
{
    public partial class AddDataToTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "lorem ipsum", "Ropa de Dama" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "lorem ipsum", "Ropa de Varon" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 3, "lorem ipsum", "Ropa de Bebe" });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Active", "CategoryId", "Description", "Name", "ProductUrl", "UnitPrice" },
                values: new object[] { 1, true, 1, "lorem ipsum", "Producto 1", null, 20m });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "Active", "CategoryId", "Description", "Name", "ProductUrl", "UnitPrice" },
                values: new object[] { 2, true, 1, "lorem ipsum", "Producto 2", null, 50m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
