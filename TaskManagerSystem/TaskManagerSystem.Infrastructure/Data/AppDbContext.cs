using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManagerSystem.Core.Entities;
using TaskManagerSystem.Infrastructure.Configurations;

namespace TaskManagerSystem.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<User>(options)
{
    // Declaras solo las entidades adicionales que tú defines
    public DbSet<Project> Projects { get; set; } = null!;
    public DbSet<ToDoTask> ToDoTasks { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Aplicar configuraciones personalizadas para tus entidades
        ModelConfiguration.ApplyConfigurations(modelBuilder);
    }
}