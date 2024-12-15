using Microsoft.EntityFrameworkCore;
using Modules.WorkManagement.Core.Entities;

namespace Modules.WorkManagement.Core.Abstractions;

public interface IWorkManagementDbContext
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<ToDoTask> ToDoTasks { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}