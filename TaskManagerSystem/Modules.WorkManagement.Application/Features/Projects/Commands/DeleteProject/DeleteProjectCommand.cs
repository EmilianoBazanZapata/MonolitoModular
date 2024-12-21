using MediatR;

namespace Modules.WorkManagement.Application.Features.Projects.Commands.DeleteProject;

public record DeleteProjectCommand(int Id) : IRequest<Unit>;