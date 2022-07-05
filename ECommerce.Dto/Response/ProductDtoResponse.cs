namespace ECommerce.Dto.Response;

public class ProductDtoResponse
{
    public int ProductId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Category { get; set; } = null!;
    public decimal UnitPrice { get; set; }
    public string? ProductUrl { get; set; }
}