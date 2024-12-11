using FluentValidation;
using TaskManagerSystem.Application.DTOs;
using TaskManagerSystem.Application.DTOs.User;

namespace TaskManagerSystem.Application.Validations;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator()
    {
        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("The email is required.")
            .EmailAddress().WithMessage("The email must be a valid email address.");

        RuleFor(user => user.Password)
            .NotEmpty().WithMessage("The password is required.")
            .MinimumLength(6).WithMessage("The password must be at least 6 characters long.")
            .Matches(@"[A-Z]").WithMessage("The password must contain at least one uppercase letter.")
            .Matches(@"[a-z]").WithMessage("The password must contain at least one lowercase letter.")
            .Matches(@"[0-9]").WithMessage("The password must contain at least one number.")
            .Matches(@"[\W]").WithMessage("The password must contain at least one special character.");

        RuleFor(user => user.UserName)
            .NotEmpty().WithMessage("The first name is required.")
            .MinimumLength(2).WithMessage("The first name must be at least 2 characters long.")
            .MaximumLength(50).WithMessage("The first name cannot exceed 50 characters.");
    }
}