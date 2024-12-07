using Microsoft.EntityFrameworkCore;
using TaskManagerSystem.Core.Entities;
using TaskManagerSystem.Infrastructure.Configurations;

namespace TaskManagerSystem.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Project> Projects { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        ModelConfiguration.ApplyConfigurations(modelBuilder);
    }
}