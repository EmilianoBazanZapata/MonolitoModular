using MediatR;
using Modules.WorkManagement.Core.DTOs.Task;

namespace Modules.Users.Application.Features.Users.Commands.UpdateUser;

public record UpdateUserCommand(string Id, UpdateUserDto User) : IRequest;