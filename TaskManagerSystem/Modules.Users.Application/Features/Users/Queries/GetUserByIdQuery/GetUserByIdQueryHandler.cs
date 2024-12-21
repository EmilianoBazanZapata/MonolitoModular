using MediatR;
using Microsoft.AspNetCore.Identity;
using Modules.User.Users.Entities;
using Modules.WorkManagement.Core.DTOs.Task;
using TaskManager.Shared.Core.Exceptions;

namespace Modules.Users.Application.Features.Users.Queries.GetUserByIdQuery;

public class GetUserByIdQueryHandler(UserManager<UserEntity> userManager)
    : IRequestHandler<GetUserByIdQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByIdAsync(request.Id) ?? throw new NotFoundException("User not found.");
        return new UserDto(user.Id, user.UserName, user.Email);
    }
}