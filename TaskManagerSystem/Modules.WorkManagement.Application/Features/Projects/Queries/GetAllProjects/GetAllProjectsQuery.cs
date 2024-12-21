using MediatR;
using Modules.WorkManagement.Core.DTOs.Project;

namespace Modules.WorkManagement.Application.Features.Projects.Queries.GetAllProjects;

public record GetAllProjectsQuery : IRequest<IEnumerable<GetProjectDto>>;