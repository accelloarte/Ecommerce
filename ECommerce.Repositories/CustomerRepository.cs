using ECommerce.DataAccess;
using ECommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ECommerceDbContext _context;

    public CustomerRepository(ECommerceDbContext context)
    {
        _context = context;
    }
    public async Task<(ICollection<Customer> Collection, int Total)> GetCollectionAsync(string filter, int page, int rows)
    {
        var collection = await _context.Set<Customer>()
            .AsNoTracking() // Optimizar el query para que no use el Change traking
            .Where(p => p.FirstName.Contains(filter))
            .OrderBy(x => x.FirstName)
            .Skip((page - 1) * rows)
            .Take(rows)
            .ToListAsync();

        var totalCount = await _context.Set<Customer>()
            .Where(p => p.FirstName.Contains(filter))
            .AsNoTracking()
            .CountAsync();

        return (collection, totalCount);
    }

    public async Task<Customer?> GetByIdAsync(int id)
    {
        return await _context.Set<Customer>()
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task<Customer?> GetByEmailAsync(string email)
    {
        return await _context.Set<Customer>()
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Email == email);
    }

    public async Task<int> CreateAsync(Customer entity)
    {
        await _context.Set<Customer>().AddAsync(entity);

        await _context.SaveChangesAsync();

        return entity.Id;
    }

    public async Task UpdateAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await GetByIdAsync(id);
        if (entity != null)
        {
            entity.Status = false;
            _context.Entry(entity).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }
    }
}