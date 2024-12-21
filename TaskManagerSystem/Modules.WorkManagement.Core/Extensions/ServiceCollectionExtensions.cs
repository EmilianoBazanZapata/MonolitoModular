using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Modules.WorkManagement.Core.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWorkManagementCore(this IServiceCollection services)
    {
        return services;
    }
}