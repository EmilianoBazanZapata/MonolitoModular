using FluentValidation;
using Modules.WorkManagement.Application.Features.Projects.Commands.UpdateProject;

namespace Modules.WorkManagement.Application.Features.Projects.Validators;

public class UpdateProjectDtoValidator : AbstractValidator<UpdateProjectCommand>
{
    public UpdateProjectDtoValidator()
    {
        RuleFor(project => project.Id)
            .GreaterThan(0)
            .WithMessage("The project ID must be greater than 0.");

        RuleFor(project => project.Name)
            .NotEmpty()
            .WithMessage("The project name is required.")
            .MinimumLength(3)
            .WithMessage("The project name must be at least 3 characters long.")
            .MaximumLength(100)
            .WithMessage("The project name cannot exceed 100 characters.");

        RuleFor(project => project.Description)
            .MaximumLength(500)
            .WithMessage("The project description cannot exceed 500 characters.")
            .When(project => !string.IsNullOrEmpty(project.Description));

        RuleFor(project => project.StartDate)
            .LessThanOrEqualTo(project => project.EndDate)
            .WithMessage("The start date cannot be after the end date.");
    }
}