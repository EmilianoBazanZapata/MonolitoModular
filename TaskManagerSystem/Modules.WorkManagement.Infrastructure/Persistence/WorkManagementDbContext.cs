using Microsoft.EntityFrameworkCore;
using Modules.User.Users.Abstractions;
using Modules.WorkManagement.Core.Abstractions;
using Modules.WorkManagement.Core.Entities;
using TaskManager.Shared.Infrastructure.Persistance;

namespace Modules.WorkManagement.Infrastructure.Persistence;

public class WorkManagementDbContext(DbContextOptions options) : ModuleDbContext(options), IWorkManagementDbContext
{
    public DbSet<Project> Projects { get; set; }
    
    public DbSet<ToDoTask> ToDoTasks { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}