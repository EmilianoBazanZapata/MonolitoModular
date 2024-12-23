using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Modules.User.Users.Abstractions;

namespace Modules.Users.Infrastructure.Persistence
{
    public class UserDbContext(DbContextOptions<UserDbContext> options) : IdentityDbContext(options), IUserDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}