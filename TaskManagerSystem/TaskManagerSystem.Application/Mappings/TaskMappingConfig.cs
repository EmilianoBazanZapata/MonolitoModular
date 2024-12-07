using Mapster;
using TaskManagerSystem.Application.DTOs;
using TaskManagerSystem.Application.Interfaces;
using TaskManagerSystem.Core.Entities;

namespace TaskManagerSystem.Application.Mappings;

public class TaskMappingConfig : IMapsterConfiguration
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<ToDoTask, TaskDto>();
        config.NewConfig<TaskDto, ToDoTask>();
    }
}