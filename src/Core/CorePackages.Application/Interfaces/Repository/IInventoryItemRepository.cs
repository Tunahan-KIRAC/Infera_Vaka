using CorePackages.Domain.Entities;

namespace CorePackages.Application.Interfaces.Repository;

public interface IInventoryItemRepository : IGenericRepositoryAsync<InventoryItem>
{
}
