using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.WorkManagement.Core.Extensions;
using Modules.WorkManagement.Infrastructure.Extensions;

namespace Modules.WorkManagement.Controllers.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWorkManagementControllers(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddWorkManagementCore()
                .AddWorkManagementInfrastructure(configuration);
        
        return services;
    }
}