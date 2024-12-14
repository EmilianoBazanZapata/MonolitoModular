using FluentValidation;
using FluentValidation.AspNetCore;
using TaskManagerSystem.Application.Mappings;
using TaskManagerSystem.Application.Validations;

namespace TaskManagerSystem.Api;

public static class ApiServiceRegistration
{
    public static IServiceCollection AddApiServices (this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        
        services.AddSwaggerGen();
        
        // Registrar validadores de FluentValidation
        services.AddValidatorsFromAssemblyContaining<CreateTaskDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<CreateUserDtoValidator>();
            
        // Registrar FluentValidation en los controladores
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        
        MapsterConfig.RegisterMappings();
        
        return services;
    }
}