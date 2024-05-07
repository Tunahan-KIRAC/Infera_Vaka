using CorePackages.Application.Interfaces.Repository;
using CorePackages.Domain.Entities;
using CorePackeges.Persistence.Context;

namespace CorePackeges.Persistence.Repositories;

public class RoomRepository : GenericRepository<Room>, IRoomRepository
{
    public RoomRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
