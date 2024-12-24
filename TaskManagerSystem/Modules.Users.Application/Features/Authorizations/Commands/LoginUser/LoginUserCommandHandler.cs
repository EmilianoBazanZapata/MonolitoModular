using MediatR;
using Microsoft.AspNetCore.Identity;
using TaskManager.Shared.Application.Services;
using TaskManager.Shared.Core.Exceptions;

namespace Modules.Users.Application.Features.Authorizations.Commands.LoginUser;

public record LoginUserCommandHandler(UserManager<IdentityUser> _userManager, TokenService _tokenService) : IRequestHandler<LoginUserCommand, string>
{
    public async Task<string> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.LoginDto.Email);

        if (user == null || !await _userManager.CheckPasswordAsync(user, request.LoginDto.Password))
            throw new UnauthorizedException("Invalid credentials.");

        var roles = await _userManager.GetRolesAsync(user);
        
        return _tokenService.GenerateToken(user.Id, user.Email, roles);
    }
}