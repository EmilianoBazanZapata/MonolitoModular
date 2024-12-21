using MediatR;
using Microsoft.EntityFrameworkCore;
using Modules.WorkManagement.Core.Abstractions;
using Modules.WorkManagement.Core.DTOs.Task;

namespace Modules.WorkManagement.Application.Features.Tasks.Queries.GetAllTasksQuery;

public class GetAllTasksQueryHandler(IWorkManagementDbContext context)
    : IRequestHandler<GetAllTasksQuery, IEnumerable<GetTaskDto>>
{
    public async Task<IEnumerable<GetTaskDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
    {
        var tasks = await context.ToDoTasks.ToListAsync(cancellationToken);

        return tasks.Select(t=> new GetTaskDto
        {
            Id = t.Id,
            Name = t.Name,
            Description = t.Description,
            ProjectId = t.ProjectId,
            DueDate = t.DueDate,
            CreatedAt = t.CreatedAt,
            UpdatedAt = t.UpdatedAt
        });
    }
}
