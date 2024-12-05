using TaskManagerSystem.Core.Entities;
using TaskManagerSystem.Core.Interfaces;
using TaskManagerSystem.Infrastructure.Data;

namespace TaskManagerSystem.Infrastructure.Repositories;

public class UserRepository(AppDbContext context) : GenericRepository<User>(context), IUserRepository
{
    // Métodos específicos de User pueden implementarse aquí si es necesario
}