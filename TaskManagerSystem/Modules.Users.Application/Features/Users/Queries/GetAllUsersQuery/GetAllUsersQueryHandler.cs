using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Modules.User.Users.DTOs;
using Modules.WorkManagement.Core.DTOs.Task;

namespace Modules.Users.Application.Features.Users.Queries.GetAllUsersQuery;

public class GetAllUsersQueryHandler(UserManager<IdentityUser> userManager)
    : IRequestHandler<GetAllUsersQuery, IEnumerable<GetUserDto>>
{
    public async Task<IEnumerable<GetUserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await userManager.Users.ToListAsync(cancellationToken: cancellationToken);
        return users.Select(u => new GetUserDto(u.Id, u.UserName, u.Email));
    }
}