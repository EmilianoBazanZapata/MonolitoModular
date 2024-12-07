using TaskManagerSystem.Application.DTOs;
using TaskManagerSystem.Core.Entities;
using TaskManagerSystem.Core.Interfaces;

namespace TaskManagerSystem.Application.Services;

public class TaskService(ITaskRepository taskRepository)
{
    public async Task<IEnumerable<TaskDto>> GetAllTasksAsync()
    {
        var tasks = await taskRepository.GetAllAsync();
        return tasks.Select(task => new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            Status = task.Status,
            ProjectId = task.ProjectId
        });
    }

    public async Task<TaskDto?> GetTaskByIdAsync(int id)
    {
        var task = await taskRepository.GetByIdAsync(id);
        if (task == null) return null;

        return new TaskDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            Status = task.Status,
            ProjectId = task.ProjectId
        };
    }

    public async Task AddTaskAsync(TaskDto taskDto)
    {
        var task = new ToDoTask
        {
            Title = taskDto.Title,
            Description = taskDto.Description,
            DueDate = taskDto.DueDate,
            Status = taskDto.Status,
            ProjectId = taskDto.ProjectId
        };

        await taskRepository.AddAsync(task);
    }

    public async Task UpdateTaskAsync(TaskDto taskDto)
    {
        var task = await taskRepository.GetByIdAsync(taskDto.Id);
        if (task == null) throw new Exception("Task not found.");

        task.Title = taskDto.Title;
        task.Description = taskDto.Description;
        task.DueDate = taskDto.DueDate;
        task.Status = taskDto.Status;

        await taskRepository.UpdateAsync(task);
    }

    public async Task DeleteTaskAsync(int id)
    {
        var task = await taskRepository.GetByIdAsync(id);
        if (task == null) throw new Exception("Task not found.");

        await taskRepository.DeleteAsync(task.Id);
    }
}