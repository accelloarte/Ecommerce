using ECommerce.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace ECommerceTest;

public class DbContextUnitTest
{
    protected readonly ECommerceDbContext Context;

    protected DbContextUnitTest()
    {
        var options = new DbContextOptionsBuilder<ECommerceDbContext>()
            .UseInMemoryDatabase("ECommerceDB")
            .Options;

        Context = new ECommerceDbContext(options);

        Context.Database.EnsureCreated();
    }
}