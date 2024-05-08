using CorePackages.Application.Interfaces.Repository;
using CorePackages.Domain.Entities;
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

            serviceCollection.AddIdentityCore<User>(opt =>
            {

                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequiredLength = 2;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireDigit = false;
                opt.SignIn.RequireConfirmedEmail = false;

            })
                .AddRoles<Role>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            serviceCollection.AddScoped<IBuildingRepository, BuildingRepository>();
            serviceCollection.AddScoped<IDepotRepository, DepotRepository>();
            serviceCollection.AddScoped<IInventoryItemRepository, InventoryItemRepository>();
            serviceCollection.AddScoped<IRoomRepository, RoomRepository>();

            return serviceCollection;
        }
    }

}
