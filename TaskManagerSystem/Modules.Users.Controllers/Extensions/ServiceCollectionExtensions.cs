using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Modules.Users.Controllers.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUServiceCollectionControllers(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}