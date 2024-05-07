using CorePackages.Application.Interfaces.Repository;
using CorePackeges.Persistence.Context;
using CorePackeges.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CorePackeges.Persistence
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MyConnection")));

            serviceCollection.AddScoped<IBuildingRepository, BuildingRepository>();
            serviceCollection.AddScoped<IDepotRepository, DepotRepository>();
            serviceCollection.AddScoped<IInventoryItemRepository, InventoryItemRepository>();
            serviceCollection.AddScoped<IRoomRepository, RoomRepository>();

            return serviceCollection;
        }
    }

}
