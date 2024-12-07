namespace TaskManagerSystem.Api;

public static class ApiServiceRegistration
{
    public static IServiceCollection AddApiServices (this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        return services;
    }
}