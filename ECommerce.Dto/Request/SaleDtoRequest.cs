namespace ECommerce.Dto.Request;

public class SaleDtoRequest
{
    public int CustomerId { get; set; }

    public int PaymentMethod { get; set; }

    public ICollection<SaleDetailDtoRequest> Details { get; set; } = null!;
}

public class SaleDetailDtoRequest
{
    public int ProductId { get; set; }
    public decimal Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}