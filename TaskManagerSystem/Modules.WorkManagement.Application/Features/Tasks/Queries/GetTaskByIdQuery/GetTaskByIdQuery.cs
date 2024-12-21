using MediatR;
using Modules.WorkManagement.Core.DTOs.Task;

namespace Modules.WorkManagement.Application.Features.Tasks.Queries.GetTaskByIdQuery;

public record GetTaskByIdQuery(int Id) : IRequest<GetTaskDto>;
