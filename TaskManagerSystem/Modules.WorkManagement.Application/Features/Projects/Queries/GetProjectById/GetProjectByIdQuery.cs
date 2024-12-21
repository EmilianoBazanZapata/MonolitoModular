using MediatR;
using Modules.WorkManagement.Core.DTOs.Project;

namespace Modules.WorkManagement.Application.Features.Projects.Queries.GetProjectById;

public record GetProjectByIdQuery(int Id) : IRequest<GetProjectDto>;