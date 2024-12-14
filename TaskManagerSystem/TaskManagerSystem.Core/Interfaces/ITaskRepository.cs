using TaskManagerSystem.Core.Entities;

namespace TaskManagerSystem.Core.Interfaces;

public interface ITaskRepository : IGenericRepository<ToDoTask>
{
    Task<ToDoTask?> GetTaskWithUserAsync(int taskId);
}