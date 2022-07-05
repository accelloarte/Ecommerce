using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.DataAccess.Migrations
{
    public partial class RenameCustomersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1992, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "51819" });

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
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1981, 6, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "38025" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1989, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "10131" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1986, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "1795" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1993, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "5732" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1986, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "40631" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1984, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "18282" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1998, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "21071" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1998, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "34140" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1995, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "11315" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "BirthDate", "Dependants", "DocumentNumber" },
                values: new object[] { new DateTime(1987, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "41691" });

            migrationBuilder.UpdateData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "BirthDate", "DocumentNumber" },
                values: new object[] { new DateTime(1991, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "21404" });
        }
    }
}
