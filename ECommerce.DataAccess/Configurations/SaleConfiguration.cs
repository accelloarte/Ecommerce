using ECommerce.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.DataAccess.Configurations;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.HasOne(p => p.Customer)
            .WithMany()
            .HasForeignKey(p => p.CustomerFk)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(p => p.SaleDate)
            .HasColumnType("DATE")
            .HasDefaultValueSql("getdate()");

        builder.Property(p => p.TotalSale)
            .HasPrecision(8, 2);

        builder.HasIndex(p => p.InvoiceNumber)
            .IsUnique(true);

        builder.Property(p => p.PaymentMethod)
            .HasDefaultValue(PaymentMethod.Cash)
            .HasConversion<string>();
    }
}