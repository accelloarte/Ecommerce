using ECommerce.Entities;

namespace ECommerce.Repositories;

public interface ICategoryRepository
{
    Task<(ICollection<Category> Collection, int Total)> GetCollectionAsync(string filter, int page, int rows);
    Task<Category?> GetByIdAsync(int id);
    Task<int> CreateAsync(Category entity);
    Task UpdateAsync();
    Task DeleteAsync(int id);
}