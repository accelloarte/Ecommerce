using System.ComponentModel.DataAnnotations;

namespace ECommerce.Entities;

public class Category : EntityBase
{
    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(200)]
    public string Description { get; set; } = null!;
}