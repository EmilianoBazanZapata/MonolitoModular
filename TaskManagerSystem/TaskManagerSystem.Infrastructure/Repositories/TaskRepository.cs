using TaskManagerSystem.Core.Entities;
using TaskManagerSystem.Core.Interfaces;
using TaskManagerSystem.Infrastructure.Data;

namespace TaskManagerSystem.Infrastructure.Repositories;

public class TaskRepository(AppDbContext context) : GenericRepository<ToDoTask>(context), ITaskRepository
{
    // Métodos específicos de Task pueden implementarse aquí si es necesario
}