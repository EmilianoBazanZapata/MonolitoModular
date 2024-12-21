using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Modules.User.Users.Abstractions;
using Modules.User.Users.Entities;

namespace Modules.Users.Infrastructure.Persistence
{
    public class UserDbContext(DbContextOptions<UserDbContext> options) : IdentityDbContext(options), IUserDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configura el modelo para UserEntity si es necesario
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.ToTable("Users"); // Opcional: especifica el nombre de la tabla
                // Configuraciones adicionales
            });
            
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}