using System.ComponentModel.DataAnnotations;

namespace ECommerce.Dto.Request;

public class CategoryDtoRequest
{
    [StringLength(50)] 
    public string Name { get; set; } = null!;

    [StringLength(100)]
    public string Description { get; set; } = null!;
}