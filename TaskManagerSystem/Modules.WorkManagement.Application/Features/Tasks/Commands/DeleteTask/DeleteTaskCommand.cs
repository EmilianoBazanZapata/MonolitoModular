using MediatR;

namespace Modules.WorkManagement.Application.Features.Tasks.Commands.DeleteTask;

public record DeleteTaskCommand(int Id) : IRequest<Unit>;