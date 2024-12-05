using TaskManagerSystem.Core.Entities;

namespace TaskManagerSystem.Core.Interfaces;

public interface ITaskRepository : IGenericRepository<ToDoTask>
{
    // Métodos específicos de Task si es necesario
}