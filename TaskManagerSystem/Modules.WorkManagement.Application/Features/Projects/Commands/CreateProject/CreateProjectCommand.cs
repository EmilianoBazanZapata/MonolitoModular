using MediatR;

namespace Modules.WorkManagement.Application.Features.Projects.Commands.CreateProject;

public class CreateProjectCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
}