using MediatR;
using Modules.User.Users.DTOs;
using Modules.WorkManagement.Core.DTOs.Task;

namespace Modules.Users.Application.Features.Users.Queries.GetAllUsersQuery;

public record GetAllUsersQuery : IRequest<IEnumerable<GetUserDto>>;