using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Users.Infrastructure.Persistence;
using TaskManager.Shared.Infrastructure.Extensions;

namespace Modules.Users.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddUserInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddDatabaseContext<UserDbContext>(config);
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
                {
                    // Configurar opciones de Identity si es necesario
                })
                .AddEntityFrameworkStores<UserDbContext>() // Configura el almacenamiento para Entity Framework
                .AddDefaultTokenProviders(); // Registra proveedores de tokens predeterminados
            
            services.AddSharedInfrastructure(config);

            return services;
        }
    }
}