using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.DataAccess.Migrations
{
    public partial class ViewForReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW vReporteVentas 
AS 
SELECT 
	P.Name ProductName,
	S.SaleDate,
	SUM(SD.TotalSale) TotalSale
FROM SaleDetail SD
INNER JOIN Sale S ON SD.SaleIdFk = S.InvoiceId
INNER JOIN Products P ON SD.ProductIdentifier = P.Id
GROUP BY P.Name, S.SaleDate;");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1983, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "29083" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1993, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "7649" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1982, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "42223" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1981, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "37653" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1991, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "58742" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1990, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "45855" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1982, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "45826" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1988, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "40953" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1980, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "35750" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1981, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "2946" });

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 1,
                column: "Ocurred",
                value: new DateTime(2022, 5, 20, 22, 2, 12, 133, DateTimeKind.Local).AddTicks(3097));

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ocurred",
                value: new DateTime(2022, 5, 20, 22, 2, 12, 133, DateTimeKind.Local).AddTicks(3111));

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 3,
                column: "Ocurred",
                value: new DateTime(2022, 5, 20, 22, 2, 12, 133, DateTimeKind.Local).AddTicks(3112));

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 4,
                column: "Ocurred",
                value: new DateTime(2022, 5, 20, 22, 2, 12, 133, DateTimeKind.Local).AddTicks(3113));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW vReporteVentas");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1987, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "56925" });

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
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1987, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "51805" });

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
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1987, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "41215" });

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
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1993, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "29806" });

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
        }
    }
}
