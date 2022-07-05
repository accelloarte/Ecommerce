using ECommerce.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.DataAccess.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder
            .Property(p => p.Name)
            .HasMaxLength(100);

        builder
            .Property(p => p.Description)
            //.IsRequired()
            .HasMaxLength(200);

        builder
            .Property(p => p.ProductUrl)
            .HasMaxLength(500)
            .IsUnicode(false);

        builder
            .Property(x => x.UnitPrice)
            .HasColumnType("money")
            .HasPrecision(8, 2)
            .IsConcurrencyToken();

        // Propiedad sombra
        //builder.Property<DateTime>("FechaCreacion")
        //    .HasColumnType("DATETIME2")
        //    .HasDefaultValueSql("GETDATE()");

        builder.ToTable("Products");

        builder.HasData(new List<Product>()
        {
            new Product()
            {
                Id = 1, CategoryId = 1, Active = true, Name = "Producto 1",
                Description = "lorem ipsum", UnitPrice = 20
            },
            new Product()
            {
                Id = 2, CategoryId = 1, Active = true, Name = "Producto 2",
                Description = "lorem ipsum", UnitPrice = 50
            },
        });

        // Esto no requiere hacer un migration.

        //builder.HasQueryFilter(p => p.Status);
    }
}