using ECommerce.DataAccess;
using ECommerce.Entities;

namespace ECommerce.Repositories;

public class KardexRepository : IKardexRepository
{
    private readonly ECommerceDbContext _context;

    public KardexRepository(ECommerceDbContext context)
    {
        _context = context;
    }

    public async Task RegisterMovement(int productId, long quantity, MovementType movementType)
    {
        var entity = new Kardex
        {
            ProductId = productId,
            Quantity = movementType == MovementType.Out ? quantity * -1 : Math.Abs(quantity),
            MovementType = movementType
        };

        await _context.Set<Kardex>().AddAsync(entity);
    }
}