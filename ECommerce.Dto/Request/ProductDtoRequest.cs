namespace ECommerce.Dto.Request
{
    public class ProductDtoRequest
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal UnitPrice { get; set; }
        public int IdCategory { get; set; }
        public string? ProductUrl { get; set; }
        public string? Base64Image { get; set; }
        public string? FileName { get; set; }
        public bool? Active { get; set; }
    }
}