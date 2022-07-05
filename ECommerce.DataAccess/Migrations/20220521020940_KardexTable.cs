using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.DataAccess.Migrations
{
    public partial class KardexTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kardex",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Ocurred = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false),
                    MovementType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kardex", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kardex_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1984, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "6625" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1990, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "56744" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1995, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "9792" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1986, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "18437" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1980, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "28320" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1989, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "11565" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1981, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "36129" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1980, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "497" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1987, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "43795" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1996, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "51830" });

            migrationBuilder.InsertData(
                table: "Kardex",
                columns: new[] { "Id", "MovementType", "Ocurred", "ProductId", "Quantity", "Status" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2022, 5, 20, 21, 9, 39, 786, DateTimeKind.Local).AddTicks(8843), 3, 200L, true },
                    { 2, 2, new DateTime(2022, 5, 20, 21, 9, 39, 786, DateTimeKind.Local).AddTicks(8855), 4, 100L, true },
                    { 3, 2, new DateTime(2022, 5, 20, 21, 9, 39, 786, DateTimeKind.Local).AddTicks(8856), 5, 10L, true },
                    { 4, 2, new DateTime(2022, 5, 20, 21, 9, 39, 786, DateTimeKind.Local).AddTicks(8856), 6, 2L, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kardex_ProductId",
                table: "Kardex",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kardex");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1997, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "59559" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1982, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "7274" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1986, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "59692" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1994, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "9021" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1985, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "49180" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1986, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "9906" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1994, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "18462" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1996, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "52783" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1988, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "24777" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1984, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "41580" });
        }
    }
}
