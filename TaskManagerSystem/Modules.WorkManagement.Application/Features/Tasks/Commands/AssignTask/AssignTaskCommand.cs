using MediatR;

namespace Modules.WorkManagement.Application.Features.Tasks.Commands.AssignTask;

public record AssignTaskCommand(int TaskId, string UserId) : IRequest<Unit>;