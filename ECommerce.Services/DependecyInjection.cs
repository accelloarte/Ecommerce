using ECommerce.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Services;

public static class DependecyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
    {
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<ICustomerRepository, CustomerRepository>();
        services.AddTransient<ISaleRepository, SaleRepository>();
        services.AddTransient<IKardexRepository, KardexRepository>();

        services.AddTransient<ICategoryService, CategoryService>();
        services.AddTransient<IProductService, ProductService>();
        services.AddTransient<ICustomerService, CustomerService>();
        services.AddTransient<ISaleService, SaleService>();

        services.AddTransient<IUserService, UserService>();
        services.AddTransient<ISecretService, SecretService>();

        return services;
    }
}