using MediatR;

namespace Modules.WorkManagement.Application.Features.Projects.Commands.DeleteProject;

public class DeleteProjectCommand(int id) : IRequest<Unit>
{
    public int Id { get; set; } = id;
}