using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.DataAccess.Migrations
{
    public partial class ConcurrencyByRow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Version",
                table: "Customers",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BirthDate", "Dependants", "DocumentNumber", "Email", "FirstName", "LastName", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(1987, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "6727", "customer0001@gmail.com", "Customer N°1", "lorem ipsum 0", true },
                    { 2, new DateTime(1981, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "43847", "customer0002@gmail.com", "Customer N°2", "lorem ipsum 3", true },
                    { 3, new DateTime(1987, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "316", "customer0003@gmail.com", "Customer N°3", "lorem ipsum 6", true },
                    { 4, new DateTime(1993, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "48615", "customer0004@gmail.com", "Customer N°4", "lorem ipsum 9", true },
                    { 5, new DateTime(1998, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "39128", "customer0005@gmail.com", "Customer N°5", "lorem ipsum 12", true },
                    { 6, new DateTime(1994, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "33996", "customer0006@gmail.com", "Customer N°6", "lorem ipsum 15", true },
                    { 7, new DateTime(1990, 2, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "15015", "customer0007@gmail.com", "Customer N°7", "lorem ipsum 18", true },
                    { 8, new DateTime(1986, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "52065", "customer0008@gmail.com", "Customer N°8", "lorem ipsum 21", true },
                    { 9, new DateTime(1985, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "21031", "customer0009@gmail.com", "Customer N°9", "lorem ipsum 24", true },
                    { 10, new DateTime(1998, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "45818", "customer0010@gmail.com", "Customer N°10", "lorem ipsum 27", true }
                });

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 1,
                column: "Ocurred",
                value: new DateTime(2022, 5, 25, 20, 6, 41, 323, DateTimeKind.Local).AddTicks(9490));

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 2,
                column: "Ocurred",
                value: new DateTime(2022, 5, 25, 20, 6, 41, 323, DateTimeKind.Local).AddTicks(9542));

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 3,
                column: "Ocurred",
                value: new DateTime(2022, 5, 25, 20, 6, 41, 323, DateTimeKind.Local).AddTicks(9543));

            migrationBuilder.UpdateData(
                table: "Kardex",
                keyColumn: "Id",
                keyValue: 4,
                column: "Ocurred",
                value: new DateTime(2022, 5, 25, 20, 6, 41, 323, DateTimeKind.Local).AddTicks(9544));
        }
    }
}
