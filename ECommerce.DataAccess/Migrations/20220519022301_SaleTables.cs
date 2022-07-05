using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.DataAccess.Migrations
{
    public partial class SaleTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    InvoiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerFk = table.Column<int>(type: "int", nullable: false),
                    SaleDate = table.Column<DateTime>(type: "DATE", nullable: false, defaultValueSql: "getdate()"),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    TotalSale = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Sale_Customers_CustomerFk",
                        column: x => x.CustomerFk,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleDetail",
                columns: table => new
                {
                    SaleDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SaleIdFk = table.Column<int>(type: "int", nullable: false),
                    ProductIdentifier = table.Column<int>(type: "int", nullable: false),
                    ItemNumber = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false),
                    TotalSale = table.Column<decimal>(type: "decimal(8,2)", precision: 8, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleDetail", x => x.SaleDetailId);
                    table.ForeignKey(
                        name: "FK_SaleDetail_Products_ProductIdentifier",
                        column: x => x.ProductIdentifier,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleDetail_Sale_SaleIdFk",
                        column: x => x.SaleIdFk,
                        principalTable: "Sale",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1982, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "34885" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1986, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "51036" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1998, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "9363" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1993, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "57552" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1981, 6, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "54864" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1992, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "19677" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1988, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "43409" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1988, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "21837" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1981, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "5896" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1981, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "18809" });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DocumentNumber",
                table: "Customers",
                column: "DocumentNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sale_CustomerFk",
                table: "Sale",
                column: "CustomerFk",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sale_InvoiceNumber",
                table: "Sale",
                column: "InvoiceNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetail_ProductIdentifier",
                table: "SaleDetail",
                column: "ProductIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetail_SaleIdFk",
                table: "SaleDetail",
                column: "SaleIdFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleDetail");

            migrationBuilder.DropTable(
                name: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Customers_DocumentNumber",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1992, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "51819" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1994, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "2666" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1989, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "17203" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1982, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "357" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1983, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "40752" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1986, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "19876" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1992, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "22416" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1982, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "19671" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1988, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "52693" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1981, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "38025" });
        }
    }
}
