using Mapster;
using TaskManagerSystem.Application.DTOs;
using TaskManagerSystem.Core.Entities;
using TaskManagerSystem.Core.Interfaces;

namespace TaskManagerSystem.Application.Services;

public class TaskService(ITaskRepository taskRepository)
{
    // Obtener todas las tareas
    public async Task<IEnumerable<TaskDto>> GetAllTasksAsync()
    {
        var tasks = await taskRepository.GetAllAsync();
        return tasks.Adapt<IEnumerable<TaskDto>>();
    }

    // Obtener una tarea por ID
    public async Task<TaskDto?> GetTaskByIdAsync(int id)
    {
        var task = await taskRepository.GetByIdAsync(id);
        return task?.Adapt<TaskDto>();
    }

    // Crear una nueva tarea
    public async Task<ToDoTask> AddTaskAsync(TaskDto taskDto)
    {
        var task = taskDto.Adapt<ToDoTask>();
        await taskRepository.AddAsync(task);
        return task;
    }

    // Actualizar una tarea existente
    public async Task<ToDoTask> UpdateTaskAsync(TaskDto taskDto)
    {
        var task = await taskRepository.GetByIdAsync(taskDto.Id);
        if (task == null) throw new KeyNotFoundException($"Task with ID {taskDto.Id} not found.");

        taskDto.Adapt(task);
        await taskRepository.UpdateAsync(task);

        return task;
    }

    // Eliminar una tarea
    public async Task<ToDoTask> DeleteTaskAsync(int id)
    {
        var task = await taskRepository.GetByIdAsync(id);
        if (task == null) throw new KeyNotFoundException($"Task with ID {id} not found.");

        await taskRepository.DeleteAsync(task.Id);
        return task;
    }
}