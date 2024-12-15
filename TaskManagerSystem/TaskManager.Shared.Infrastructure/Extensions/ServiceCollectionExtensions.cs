using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManager.Shared.Infrastructure.Controllers;

namespace TaskManager.Shared.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSharedInfrastructure(this IServiceCollection services, IConfiguration config)
    {

        // Agregar soporte para controladores
        services.AddControllers()
                .ConfigureApplicationPartManager(manager =>
                {
                    manager.FeatureProviders.Add(new InternalControllerFeatureProvider());
                });

        return services;
    }

    public static IServiceCollection AddDatabaseContext<T>(this IServiceCollection services, IConfiguration config) where T : DbContext
    {
        // Obtiene la cadena de conexi�n desde la configuraci�n
        var connectionString = config.GetConnectionString("Default");

        // Configura el contexto de base de datos con PostgreSQL
        services.AddDbContext<T>(options =>
        {
            options.UseNpgsql(connectionString, npgsqlOptions =>
            {
                npgsqlOptions.MigrationsAssembly(typeof(T).Assembly.FullName);
            });
        });

        // Aplica migraciones autom�ticamente
        using var scope = services.BuildServiceProvider().CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<T>();
        dbContext.Database.Migrate();

        return services;
    }
}
