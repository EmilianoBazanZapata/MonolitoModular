using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaskManagerSystem.Application.DTOs.Token;

namespace TaskManagerSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(UserManager<IdentityUser> userManager, TokenService tokenService)
    : ControllerBase
{
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var user = await userManager.FindByEmailAsync(loginDto.Email);
        if (user == null || !await userManager.CheckPasswordAsync(user, loginDto.Password))
        {
            return Unauthorized(new { Message = "Invalid credentials." });
        }

        var roles = await userManager.GetRolesAsync(user);
        var token = tokenService.GenerateToken(user.Id, user.Email, roles);

        return Ok(new
        {
            Token = token,
            Expiration = DateTime.UtcNow.AddHours(2)
        });
    }
}
