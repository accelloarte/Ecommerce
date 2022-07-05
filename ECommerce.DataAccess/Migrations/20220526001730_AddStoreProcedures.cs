using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerce.DataAccess.Migrations
{
    public partial class AddStoreProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE uspSelectDetails (@SaleId INT)
           AS
               BEGIN


           SELECT
           SD.SaleDetailId Id,
               SD.ItemNumber,
           P.Name ProductName,
               SD.Quantity,
           SD.UnitPrice,
           SD.TotalSale Total
           FROM SaleDetail SD(NOLOCK)
           INNER JOIN Products P(NOLOCK) ON SD.ProductIdentifier = P.Id
           AND P.Active = 1
           WHERE SD.SaleIdFk = @SaleId
           ORDER BY SD.ItemNumber

               END
           GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE uspSelectDetails");
        }
    }
}
