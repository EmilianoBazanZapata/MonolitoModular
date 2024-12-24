using MediatR;
using Modules.User.Users.DTOs;

namespace Modules.Users.Application.Features.Authorizations.Commands.LoginUser;

public record LoginUserCommand (LoginDto LoginDto) : IRequest<string>;