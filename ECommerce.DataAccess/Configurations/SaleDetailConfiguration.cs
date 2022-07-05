using ECommerce.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.DataAccess.Configurations;

public class SaleDetailConfiguration : IEntityTypeConfiguration<SaleDetail>
{
    public void Configure(EntityTypeBuilder<SaleDetail> builder)
    {
        builder.HasOne(p => p.Sale)
            .WithMany()
            .HasForeignKey(p => p.SaleIdFk)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(p => p.Product)
            .WithMany()
            .HasForeignKey(p => p.ProductIdentifier)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(p => p.UnitPrice)
            .HasPrecision(8, 2);
        
        builder.Property(p => p.Quantity)
            .HasPrecision(8, 2);
        
        builder.Property(p => p.TotalSale)
            .HasPrecision(8, 2);
    }
}