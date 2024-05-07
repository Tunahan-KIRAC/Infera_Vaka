using CorePackages.Application.Interfaces.Repository;
using CorePackages.Domain.Entities;
using CorePackeges.Persistence.Context;

namespace CorePackeges.Persistence.Repositories;

public class BuildingRepository : GenericRepository<Building>, IBuildingRepository
{
    public BuildingRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
