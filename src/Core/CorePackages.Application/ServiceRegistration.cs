using CorePackages.Application.Mapping;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CorePackages.Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(GeneralMapping));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
