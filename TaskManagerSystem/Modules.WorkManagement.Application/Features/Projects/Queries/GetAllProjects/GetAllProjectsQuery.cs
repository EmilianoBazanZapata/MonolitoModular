using MediatR;
using Modules.WorkManagement.Core.DTOs.Project;

namespace Modules.WorkManagement.Application.Features.Projects.Queries.GetAllProjects;

public class GetAllProjectsQuery : IRequest<IEnumerable<GetProjectDto>> { }