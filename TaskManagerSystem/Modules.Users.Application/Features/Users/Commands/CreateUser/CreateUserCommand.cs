using MediatR;
using Modules.WorkManagement.Core.DTOs;
using Modules.WorkManagement.Core.DTOs.Task;

namespace Modules.Users.Application.Features.Users.Commands.CreateUser;

public record CreateUserCommand(CreateUserDto User) : IRequest<UserDto>;