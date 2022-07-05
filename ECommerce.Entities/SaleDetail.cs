using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Entities;

public class SaleDetail
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int SaleDetailId { get; set; }

    public Sale Sale { get; set; } = null!;

    public int SaleIdFk { get; set; }

    public Product Product { get; set; } = null!;

    public int ProductIdentifier { get; set; }

    public int ItemNumber { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Quantity { get; set; }

    public decimal TotalSale { get; set; }
}