using ECommerce.Entities;

namespace ECommerce.Repositories;

public interface IKardexRepository
{
    Task RegisterMovement(int productId, long quantity, MovementType movementType);

}