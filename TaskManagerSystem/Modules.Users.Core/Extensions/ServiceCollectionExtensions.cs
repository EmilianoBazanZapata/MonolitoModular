using Microsoft.Extensions.DependencyInjection;

namespace Modules.User.Users.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUserCore(this IServiceCollection services)
    {
        return services;
    }
}