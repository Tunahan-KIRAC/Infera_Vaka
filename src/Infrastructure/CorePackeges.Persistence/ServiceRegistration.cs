using CorePackages.Application.Interfaces.Repository;
using CorePackages.Application.Interfaces.Tokens;
using CorePackages.Domain.Entities;
using CorePackeges.Persistence.Context;
using CorePackeges.Persistence.Repositories;
using CorePackeges.Persistence.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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

            serviceCollection.Configure<TokenSettings>(configuration.GetSection("JWT"));
            serviceCollection.AddTransient<ITokenService, TokenService>();
            serviceCollection.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
            {
                opt.SaveToken = true;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"])),
                    ValidateLifetime = false,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    ClockSkew = TimeSpan.Zero
                };
            });


            serviceCollection.AddScoped<IBuildingRepository, BuildingRepository>();
            serviceCollection.AddScoped<IDepotRepository, DepotRepository>();
            serviceCollection.AddScoped<IInventoryItemRepository, InventoryItemRepository>();
            serviceCollection.AddScoped<IRoomRepository, RoomRepository>();

            return serviceCollection;
        }


    }

}
