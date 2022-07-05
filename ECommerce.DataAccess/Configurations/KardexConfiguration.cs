using ECommerce.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.DataAccess.Configurations;

public class KardexConfiguration : IEntityTypeConfiguration<Kardex>
{
    public void Configure(EntityTypeBuilder<Kardex> builder)
    {
        builder.ToTable("Kardex");

        var list = new List<Kardex>
        {
            new Kardex
            {
                Id = 1, 
                ProductId = 3,
                MovementType = MovementType.Inventory,
                Quantity = 200
            },
            new Kardex
            {
                Id = 2, 
                ProductId = 4,
                MovementType = MovementType.Inventory,
                Quantity = 100
            },
            new Kardex
            {
                Id = 3, 
                ProductId = 5,
                MovementType = MovementType.Inventory,
                Quantity = 10
            },
            new Kardex
            {
                Id = 4, 
                ProductId = 6,
                MovementType = MovementType.Inventory,
                Quantity = 2
            }
        };

        builder.HasData(list);
    }
}