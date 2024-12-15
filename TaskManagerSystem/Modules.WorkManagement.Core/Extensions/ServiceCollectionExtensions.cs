using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Modules.WorkManagement.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWorkManagementCore(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}