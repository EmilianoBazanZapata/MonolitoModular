using TaskManagerSystem.Core.Entities;
using TaskManagerSystem.Core.Interfaces;
using TaskManagerSystem.Infrastructure.Data;

namespace TaskManagerSystem.Infrastructure.Repositories;

public class ProjectRepository(AppDbContext context) : GenericRepository<Project>(context), IProjectRepository
{
    // Métodos específicos de Project pueden implementarse aquí si es necesario
}