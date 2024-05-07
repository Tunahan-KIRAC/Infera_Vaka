using CorePackages.Application.Interfaces.Repository;
using CorePackages.Domain.Entities;
using CorePackeges.Persistence.Context;

namespace CorePackeges.Persistence.Repositories;

public class DepotRepository : GenericRepository<Depot>, IDepotRepository
{
    public DepotRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
