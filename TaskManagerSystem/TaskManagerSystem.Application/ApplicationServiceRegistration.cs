using Microsoft.Extensions.DependencyInjection;
using TaskManagerSystem.Application.Services;

namespace TaskManagerSystem.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<TaskService>();
            services.AddScoped<ProjectService>();
            return services;
        }
    }
}