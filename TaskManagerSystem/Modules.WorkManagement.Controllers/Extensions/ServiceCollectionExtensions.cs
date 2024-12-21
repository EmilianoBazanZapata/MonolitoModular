using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Modules.WorkManagement.Controllers.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWorkManagementControllers(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}