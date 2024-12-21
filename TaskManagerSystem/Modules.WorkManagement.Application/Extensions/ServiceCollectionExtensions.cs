using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Modules.WorkManagement.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWorkManagementApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        return services;
    }
}