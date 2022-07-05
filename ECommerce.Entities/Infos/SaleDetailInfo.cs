namespace ECommerce.Entities.Infos;

public class SaleDetailInfo
{
    public int Id { get; set; }
    public int ItemNumber { get; set; }
    public string ProductName { get; set; } = null!;
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Total { get; set; }
}