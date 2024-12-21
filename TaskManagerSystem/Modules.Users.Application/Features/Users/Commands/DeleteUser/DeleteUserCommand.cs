using MediatR;

namespace Modules.Users.Application.Features.Users.Commands.DeleteUser;

public record DeleteUserCommand(string Id) : IRequest;