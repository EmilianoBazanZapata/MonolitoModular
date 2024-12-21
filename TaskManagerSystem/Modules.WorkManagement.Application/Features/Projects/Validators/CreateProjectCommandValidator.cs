using FluentValidation;
using Modules.WorkManagement.Application.Features.Projects.Commands.CreateProject;

namespace Modules.WorkManagement.Application.Features.Projects.Validators;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(project => project.Name)
            .NotEmpty()
            .WithMessage("The project name is required.")
            .MinimumLength(3)
            .WithMessage("The project name must be at least 3 characters long.")
            .MaximumLength(100).WithMessage("The project name cannot exceed 100 characters.");

        RuleFor(project => project.Description)
            .MaximumLength(500)
            .WithMessage("The project description cannot exceed 500 characters.")
            .When(project => !string.IsNullOrEmpty(project.Description));

        RuleFor(project => project.StartDate)
            .NotEmpty()
            .WithMessage("The start date is required.")
            .LessThanOrEqualTo(project => project.EndDate)
            .WithMessage("The start date cannot be after the end date.");

        RuleFor(project => project.EndDate)
            .NotEmpty().WithMessage("The end date is required.");
    }
}