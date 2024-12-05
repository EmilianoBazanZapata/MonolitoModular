using Microsoft.EntityFrameworkCore;
using TaskManagerSystem.Infrastructure.Data;

namespace TaskManagerSystem.Infrastructure.Configurations;

public static class ModelConfiguration
{
    public static void ApplyConfigurations(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}