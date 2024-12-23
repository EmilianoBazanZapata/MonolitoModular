using MediatR;
using Microsoft.AspNetCore.Identity;
using Modules.User.Users.DTOs;
using Modules.WorkManagement.Core.DTOs.Task;
using TaskManager.Shared.Core.Exceptions;

namespace Modules.Users.Application.Features.Users.Queries.GetUserByIdQuery;

public class GetUserByIdQueryHandler(UserManager<IdentityUser> userManager)
    : IRequestHandler<GetUserByIdQuery, GetUserDto>
{
    public async Task<GetUserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id) ?? throw new NotFoundException("User not found.");
        return new GetUserDto(user.Id, user.UserName, user.Email);
    }
}