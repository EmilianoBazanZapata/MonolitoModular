using MediatR;
using Microsoft.EntityFrameworkCore;
using Modules.WorkManagement.Core.Abstractions;
using Modules.WorkManagement.Core.DTOs.Task;
using TaskManager.Shared.Core.Exceptions;

namespace Modules.WorkManagement.Application.Features.Tasks.Queries.GetTaskByIdQuery;

public class GetTaskByIdQueryHandler(IWorkManagementDbContext context) : IRequestHandler<GetTaskByIdQuery, GetTaskDto>
{
    public async Task<GetTaskDto> Handle(GetTaskByIdQuery request, CancellationToken cancellationToken)
    {
        var task = await context.ToDoTasks
                                .FirstOrDefaultAsync(t => t.Id == request.Id, cancellationToken);

        if (task == null)
            throw new NotFoundException($"Task with ID {request.Id} not found.");

        return new GetTaskDto
        {
            Id = task.Id,
            Name = task.Name,
            Description = task.Description,
            ProjectId = task.ProjectId,
            DueDate = task.DueDate,
            CreatedAt = task.CreatedAt,
            UpdatedAt = task.UpdatedAt
        };
    }
}