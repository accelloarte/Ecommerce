using ECommerce.DataAccess;
using ECommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ECommerceDbContext _context;

    public CategoryRepository(ECommerceDbContext context)
    {
        _context = context;
    }

    public async Task<(ICollection<Category> Collection, int Total)> GetCollectionAsync(string filter, int page, int rows)
    {
        var collection = await _context.Set<Category>()
            .AsNoTracking() // Optimizar el query para que no use el Change traking
            .Where(p => p.Name.StartsWith(filter))
            .OrderBy(x => x.Name)
            .Skip((page - 1) * rows)
            .Take(rows)
            .ToListAsync();

        var totalCount = await _context.Set<Category>()
            .Where(p => p.Name.StartsWith(filter))
            .AsNoTracking()
            .CountAsync();

        return (collection, totalCount);
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        return await _context.Set<Category>()
            .IgnoreQueryFilters()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<int> CreateAsync(Category entity)
    {
        await _context.Set<Category>().AddAsync(entity);

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