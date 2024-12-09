using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskManagerSystem.Core.Interfaces;
using TaskManagerSystem.Infrastructure.Data;
using TaskManagerSystem.Infrastructure.Identity;
using TaskManagerSystem.Infrastructure.Repositories;

namespace TaskManagerSystem.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, 
            string connectionString,
            string identityConnection)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));
            
            services.AddDbContext<AppIdentityDbContext>(options => options.UseNpgsql(identityConnection));

            services.AddIdentityCore<IdentityUser>()
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}