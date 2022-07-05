using ECommerce.Entities;

namespace ECommerce.Repositories;

public interface ICustomerRepository
{
    Task<(ICollection<Customer> Collection, int Total)> GetCollectionAsync(string filter, int page, int rows);
    Task<Customer?> GetByIdAsync(int id);
    Task<Customer?> GetByEmailAsync(string email);
    Task<int> CreateAsync(Customer entity);
    Task UpdateAsync();
    Task DeleteAsync(int id);
}