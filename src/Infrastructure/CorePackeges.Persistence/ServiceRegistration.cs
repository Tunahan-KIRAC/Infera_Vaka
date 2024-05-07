using CorePackeges.Persistence.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CorePackeges.Persistence;

public static class ServiceRegistration
{
    public static IServiceCollection AddDbContextService(this IServiceCollection services)
    {
        ServiceProvider provider = services.BuildServiceProvider();
        IConfiguration configuration = provider.GetService<IConfiguration>();
        services.AddDbContextPool<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("MyConnection")));
        return services;
    }
}
