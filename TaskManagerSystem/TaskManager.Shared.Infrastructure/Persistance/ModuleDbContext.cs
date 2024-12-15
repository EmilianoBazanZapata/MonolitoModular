using Microsoft.EntityFrameworkCore;

namespace TaskManager.Shared.Infrastructure.Persistance;

public class ModuleDbContext: DbContext
{
    protected ModuleDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return (await base.SaveChangesAsync(true, cancellationToken));
    }
}