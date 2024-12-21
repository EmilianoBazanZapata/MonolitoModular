using MediatR;
using Modules.WorkManagement.Core.DTOs.Task;

namespace Modules.Users.Application.Features.Users.Queries.GetAllUsersQuery;

public record GetAllUsersQuery : IRequest<IEnumerable<UserDto>>;