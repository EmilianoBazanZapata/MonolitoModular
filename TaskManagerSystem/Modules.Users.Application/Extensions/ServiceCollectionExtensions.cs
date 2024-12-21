using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Modules.Users.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddUserApplication(this IServiceCollection services)
    {
        // Registrar los manejadores de MediatR en el ensamblado actual
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    
        return services;
    }

}