using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.DataAccess.Migrations
{
    public partial class FixTableConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ColumnaRandom",
                table: "Customers");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Customer");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Customer",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customer",
                table: "Customer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "BirthDate", "Dependants", "DocumentNumber", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1989, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "10131", "customer0001@gmail.com", "Customer N°1", "lorem ipsum 0" },
                    { 2, new DateTime(1986, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "1795", "customer0002@gmail.com", "Customer N°2", "lorem ipsum 3" },
                    { 3, new DateTime(1993, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "5732", "customer0003@gmail.com", "Customer N°3", "lorem ipsum 6" },
                    { 4, new DateTime(1986, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "40631", "customer0004@gmail.com", "Customer N°4", "lorem ipsum 9" },
                    { 5, new DateTime(1984, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "18282", "customer0005@gmail.com", "Customer N°5", "lorem ipsum 12" },
                    { 6, new DateTime(1998, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "21071", "customer0006@gmail.com", "Customer N°6", "lorem ipsum 15" },
                    { 7, new DateTime(1998, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "34140", "customer0007@gmail.com", "Customer N°7", "lorem ipsum 18" },
                    { 8, new DateTime(1995, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "11315", "customer0008@gmail.com", "Customer N°8", "lorem ipsum 21" },
                    { 9, new DateTime(1987, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "41691", "customer0009@gmail.com", "Customer N°9", "lorem ipsum 24" },
                    { 10, new DateTime(1991, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "21404", "customer0010@gmail.com", "Customer N°10", "lorem ipsum 27" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customer",
                table: "Customer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Customer",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATE");

            migrationBuilder.AddColumn<string>(
                name: "ColumnaRandom",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
