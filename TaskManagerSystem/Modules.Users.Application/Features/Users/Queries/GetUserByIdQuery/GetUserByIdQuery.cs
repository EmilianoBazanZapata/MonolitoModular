using MediatR;
using Modules.WorkManagement.Core.DTOs.Task;

namespace Modules.Users.Application.Features.Users.Queries.GetUserByIdQuery;

public record GetUserByIdQuery(string Id) : IRequest<UserDto>;