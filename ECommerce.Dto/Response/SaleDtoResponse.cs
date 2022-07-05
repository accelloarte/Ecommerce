namespace ECommerce.Dto.Response;

public class SaleDtoResponse
{
    public int Id { get; set; }
    public string InvoiceNumber { get; set; } = null!;
    public string CustomerName { get; set; } = null!;
    public string SaleDate { get; set; } = null!;
    public decimal TotalAmount { get; set; }
    public string PaymentMethod { get; set; } = null!;
}