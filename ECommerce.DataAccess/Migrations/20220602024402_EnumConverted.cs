using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.DataAccess.Migrations
{
    public partial class EnumConverted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PaymentMethod",
                table: "Sale",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "Cash",
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PaymentMethod",
                table: "Sale",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "Cash");

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 1,
                column: "Ocurred",
                value: new DateTime(2022, 6, 1, 21, 22, 15, 706, DateTimeKind.Local).AddTicks(4187));

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ocurred",
                value: new DateTime(2022, 6, 1, 21, 22, 15, 706, DateTimeKind.Local).AddTicks(4204));

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 3,
                column: "Ocurred",
                value: new DateTime(2022, 6, 1, 21, 22, 15, 706, DateTimeKind.Local).AddTicks(4206));

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 4,
                column: "Ocurred",
                value: new DateTime(2022, 6, 1, 21, 22, 15, 706, DateTimeKind.Local).AddTicks(4207));
        }
    }
}
