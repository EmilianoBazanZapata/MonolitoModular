using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Modules.User.Users.Entities;
using Modules.WorkManagement.Core.DTOs.Task;

namespace Modules.Users.Application.Features.Users.Queries.GetAllUsersQuery;

public class GetAllUsersQueryHandler(UserManager<UserEntity> userManager)
    : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
{
    public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await userManager.Users.ToListAsync(cancellationToken: cancellationToken);
        return users.Select(u => new UserDto(u.Id, u.UserName, u.Email));
    }
}