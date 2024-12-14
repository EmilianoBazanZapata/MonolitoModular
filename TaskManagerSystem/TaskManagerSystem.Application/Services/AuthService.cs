using Mapster;
using Microsoft.AspNetCore.Identity;
using TaskManagerSystem.Application.DTOs.Token;
using TaskManagerSystem.Application.DTOs.User;
using TaskManagerSystem.Core.Entities;
using TaskManagerSystem.Core.Exceptions;

namespace TaskManagerSystem.Application.Services;

public class AuthService(UserManager<User> userManager,
    IPasswordHasher<User> passwordHasher,
                                              TokenService tokenService)
{
    public async Task<string> LoginAsync(LoginDto loginDto)
    {
        // Buscar el usuario por email
        var user = await userManager.FindByEmailAsync(loginDto.Email);
        if (user == null)
            throw new UnauthorizedException("Invalid email or password.");

        // Validar la contraseña manualmente
        var verificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);
        if (verificationResult == PasswordVerificationResult.Failed)
            throw new UnauthorizedException("Invalid email or password.");

        // Obtener roles del usuario
        var roles = await userManager.GetRolesAsync(user);

        // Generar el token
        return tokenService.GenerateToken(user.Id, user.Email, roles);
    }
    
    public async Task<GetUserDto> CreateUserAsync(CreateUserDto createUserDto)
    {
        var existingUser = await userManager.FindByEmailAsync(createUserDto.Email);
        
        if (existingUser != null)
            throw new BadRequestException("The email is already registered.");
        
        var user = createUserDto.Adapt<User>();
    
        var result = await userManager.CreateAsync(user, createUserDto.Password);
        
        if (!result.Succeeded)
            throw new BadRequestException(result.Errors.FirstOrDefault()?.Description ?? "Failed to create user.");
    
        return user.Adapt<GetUserDto>();
    }
}