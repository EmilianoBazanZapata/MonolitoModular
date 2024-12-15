using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.WorkManagement.Core.Abstractions;
using Modules.WorkManagement.Infrastructure.Persistence;
using TaskManager.Shared.Infrastructure.Extensions;


namespace Modules.WorkManagement.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCatalogInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDatabaseContext<WorkManagementDbContext>(config)
                .AddScoped<IWorkManagementDbContext>(provider => provider.GetService<WorkManagementDbContext>());
        
        return services;
    }
}