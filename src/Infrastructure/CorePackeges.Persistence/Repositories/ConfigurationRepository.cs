using CorePackages.Application.Interfaces.Repository;
using CorePackages.Domain.Entities;
using CorePackeges.Persistence.Context;

namespace CorePackeges.Persistence.Repositories;

public class ConfigurationRepository : GenericRepository<Configuration>, IConfigurationRepository
{
    public ConfigurationRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
