using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.DataAccess.Migrations
{
    public partial class RemoveFechaCreacionInProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 1,
                column: "Ocurred",
                value: new DateTime(2022, 6, 7, 21, 46, 46, 603, DateTimeKind.Local).AddTicks(8870));

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ocurred",
                value: new DateTime(2022, 6, 7, 21, 46, 46, 603, DateTimeKind.Local).AddTicks(8887));

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 3,
                column: "Ocurred",
                value: new DateTime(2022, 6, 7, 21, 46, 46, 603, DateTimeKind.Local).AddTicks(8888));

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 4,
                column: "Ocurred",
                value: new DateTime(2022, 6, 7, 21, 46, 46, 603, DateTimeKind.Local).AddTicks(8889));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Products",
                type: "DATETIME2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 1,
                column: "Ocurred",
                value: new DateTime(2022, 6, 1, 21, 44, 2, 496, DateTimeKind.Local).AddTicks(2899));

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ocurred",
                value: new DateTime(2022, 6, 1, 21, 44, 2, 496, DateTimeKind.Local).AddTicks(2920));

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 3,
                column: "Ocurred",
                value: new DateTime(2022, 6, 1, 21, 44, 2, 496, DateTimeKind.Local).AddTicks(2921));

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 4,
                column: "Ocurred",
                value: new DateTime(2022, 6, 1, 21, 44, 2, 496, DateTimeKind.Local).AddTicks(2924));
        }
    }
}
