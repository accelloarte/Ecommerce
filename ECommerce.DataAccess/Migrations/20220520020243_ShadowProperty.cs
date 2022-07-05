using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.DataAccess.Migrations
{
    public partial class ShadowProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Products",
                type: "DATETIME2",
                nullable: false,
                defaultValueSql: "GETDATE()");

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
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1994, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "9021" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1985, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "49180" });

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
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1984, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "41580" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1988, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "19607" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1991, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "31816" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1998, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "3827" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1998, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "41995" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1990, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "15378" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1991, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "16836" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1981, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "25321" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1992, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "7151" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1994, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "58671" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1994, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "55380" });
        }
    }
}
