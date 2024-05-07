using CorePackages.Application.Interfaces.Repository;
using CorePackages.Domain.Entities;
using CorePackeges.Persistence.Context;

namespace CorePackeges.Persistence.Repositories;

public class InventoryItemRepository : GenericRepository<InventoryItem>, IInventoryItemRepository
{
    public InventoryItemRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
