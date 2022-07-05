using ECommerce.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.DataAccess.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        //builder.Property(p => p.Name)
        //    .HasMaxLength(100);

        builder.ToTable("Categories");

        builder.HasData(new List<Category>()
        {
            new Category() { Id = 1, Name = "Ropa de Dama", Description = "lorem ipsum" },
            new Category() { Id = 2, Name = "Ropa de Varon", Description = "lorem ipsum" },
            new Category() { Id = 3, Name = "Ropa de Bebe", Description = "lorem ipsum" },
        });
    }
}