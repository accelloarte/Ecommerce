using ECommerce.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.DataAccess.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.Property(p => p.BirthDate)
            .HasColumnType("DATE");

        var list = new List<Customer>();
        var rnd = new Random();

        //for (int i = 0; i < 10; i++)
        //{
        //    list.Add(new Customer
        //    {
        //        Id = i+1,
        //        FirstName = $"Customer N°{i+1}",
        //        LastName = $"lorem ipsum {i *3}",
        //        BirthDate = new DateTime(rnd.Next(1980, 1999), rnd.Next(1, 12), rnd.Next(1, 28)),
        //        Dependants = rnd.Next(0, 4),
        //        DocumentNumber = rnd.Next(1, 60000).ToString("#####0"),
        //        Email = $"customer{i+1:0000}@gmail.com"
        //    });
        //}

        //builder.HasData(list);

        builder.ToTable("Customers");

        builder.HasIndex(p => p.DocumentNumber)
            .IsUnique(true);
    }
}