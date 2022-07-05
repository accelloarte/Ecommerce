using System.ComponentModel.DataAnnotations;

namespace ECommerce.Entities;

public class Product : EntityBase
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public Category Category { get; set; } = null!;
    public int CategoryId { get; set; }
    
    //[ConcurrencyCheck]
    public decimal UnitPrice { get; set; }
    public string? ProductUrl { get; set; }
    public bool Active { get; set; }
}