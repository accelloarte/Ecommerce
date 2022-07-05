using ECommerce.Entities;

namespace ECommerce.Repositories;

public interface IProductRepository
{
    Task<(ICollection<Product> Collection, int Total)> GetCollectionAsync(string filter, int page, int rows);
    Task<Product?> GetByIdAsync(int id);
    Task<int> CreateAsync(Product entity);
    Task UpdateAsync();
    Task DeleteAsync(int id);
}