using Mapster;
using TaskManagerSystem.Application.DTOs.Task;
using TaskManagerSystem.Application.Interfaces;
using TaskManagerSystem.Core.Entities;

namespace TaskManagerSystem.Application.Mappings;

public class TaskMappingConfig : IMapsterConfiguration
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ToDoTask, CreateTaskDto>();
        config.NewConfig<CreateTaskDto, ToDoTask>();
    }
}