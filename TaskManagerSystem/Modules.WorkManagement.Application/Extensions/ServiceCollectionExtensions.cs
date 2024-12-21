using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Modules.WorkManagement.Application.Features.Projects.Validators;

namespace Modules.WorkManagement.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddWorkManagementApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        services.AddValidatorsFromAssembly(typeof(CreateProjectDtoValidator).Assembly);
        services.AddValidatorsFromAssembly(typeof(UpdateProjectDtoValidator).Assembly);
        
        services.AddFluentValidationAutoValidation();
        
        return services;
    }
}