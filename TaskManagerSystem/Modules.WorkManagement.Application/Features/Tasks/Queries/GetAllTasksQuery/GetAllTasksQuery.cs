using MediatR;
using Modules.WorkManagement.Core.DTOs.Task;

namespace Modules.WorkManagement.Application.Features.Tasks.Queries.GetAllTasksQuery;

public record GetAllTasksQuery : IRequest<IEnumerable<GetTaskDto>>;
