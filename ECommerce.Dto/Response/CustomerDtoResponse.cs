namespace ECommerce.Dto.Response;

public class CustomerDtoResponse
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public int Age { get; set; }
    public string DocumentNumber { get; set; } = null!;
    public int? Dependants { get; set; }
}