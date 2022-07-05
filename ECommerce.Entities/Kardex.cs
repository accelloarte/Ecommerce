namespace ECommerce.Entities;

public class Kardex : EntityBase
{
    public Product Product { get; set; } = null!;

    public int ProductId { get; set; }

    public DateTime Ocurred { get; set; }

    public long Quantity { get; set; }

    public MovementType MovementType { get; set; }

    public Kardex()
    {
        Ocurred = DateTime.Now;
    }
}

public enum MovementType
{
    Out,
    In,
    Inventory
}