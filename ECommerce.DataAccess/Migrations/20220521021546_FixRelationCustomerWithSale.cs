using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.DataAccess.Migrations
{
    public partial class FixRelationCustomerWithSale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sale_CustomerFk",
                table: "Sale");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1987, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "56925" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1994, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "53121" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1997, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "13792" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1987, 1, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "16339" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1987, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "51805" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1992, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "36594" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1987, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "41215" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1986, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "8366" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1993, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "29806" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1992, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "57664" });

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 1,
                column: "Ocurred",
                value: new DateTime(2022, 5, 20, 21, 15, 45, 678, DateTimeKind.Local).AddTicks(1702));

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ocurred",
                value: new DateTime(2022, 5, 20, 21, 15, 45, 678, DateTimeKind.Local).AddTicks(1723));

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 3,
                column: "Ocurred",
                value: new DateTime(2022, 5, 20, 21, 15, 45, 678, DateTimeKind.Local).AddTicks(1725));

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 4,
                column: "Ocurred",
                value: new DateTime(2022, 5, 20, 21, 15, 45, 678, DateTimeKind.Local).AddTicks(1726));

            migrationBuilder.CreateIndex(
                name: "IX_Sale_CustomerFk",
                table: "Sale",
                column: "CustomerFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sale_CustomerFk",
                table: "Sale");

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
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1995, 1, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "9792" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1986, 8, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "18437" });

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
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1981, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "36129" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1980, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "497" });

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
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1996, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "51830" });

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 1,
                column: "Ocurred",
                value: new DateTime(2022, 5, 20, 21, 9, 39, 786, DateTimeKind.Local).AddTicks(8843));

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ocurred",
                value: new DateTime(2022, 5, 20, 21, 9, 39, 786, DateTimeKind.Local).AddTicks(8855));

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 3,
                column: "Ocurred",
                value: new DateTime(2022, 5, 20, 21, 9, 39, 786, DateTimeKind.Local).AddTicks(8856));

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 4,
                column: "Ocurred",
                value: new DateTime(2022, 5, 20, 21, 9, 39, 786, DateTimeKind.Local).AddTicks(8856));

            migrationBuilder.CreateIndex(
                name: "IX_Sale_CustomerFk",
                table: "Sale",
                column: "CustomerFk",
                unique: true);
        }
    }
}
