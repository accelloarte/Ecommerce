using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.DataAccess.Migrations
{
    public partial class SoftDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Customers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Status",
                value: true);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber", "Status" },
                values: new object[] { new DateTime(1988, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "19607", true });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "DocumentNumber", "Status" },
                values: new object[] { new DateTime(1991, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "31816", true });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "DocumentNumber", "Status" },
                values: new object[] { new DateTime(1998, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "3827", true });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber", "Status" },
                values: new object[] { new DateTime(1998, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "41995", true });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BirthDate", "DocumentNumber", "Status" },
                values: new object[] { new DateTime(1990, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "15378", true });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber", "Status" },
                values: new object[] { new DateTime(1991, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "16836", true });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber", "Status" },
                values: new object[] { new DateTime(1981, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "25321", true });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber", "Status" },
                values: new object[] { new DateTime(1992, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "7151", true });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber", "Status" },
                values: new object[] { new DateTime(1994, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "58671", true });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BirthDate", "DocumentNumber", "Status" },
                values: new object[] { new DateTime(1994, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "55380", true });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1982, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "34885" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1986, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "51036" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1998, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "9363" });

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
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1981, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "18809" });
        }
    }
}
