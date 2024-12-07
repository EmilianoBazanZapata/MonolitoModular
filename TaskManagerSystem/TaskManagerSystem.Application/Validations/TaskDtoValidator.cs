using FluentValidation;
using TaskManagerSystem.Application.DTOs;

namespace TaskManagerSystem.Application.Validations
{
    public class TaskDtoValidator : AbstractValidator<TaskDto>
    {
        public TaskDtoValidator()
        {
            RuleFor(task => task.Title)
                .NotEmpty().WithMessage("The title is required.")
                .MaximumLength(100).WithMessage("The title cannot exceed 100 characters.");

            RuleFor(task => task.Description)
                .MaximumLength(500).WithMessage("The description cannot exceed 500 characters.")
                .When(task => !string.IsNullOrEmpty(task.Description));

            RuleFor(task => task.DueDate)
                .NotEmpty().WithMessage("The due date is required.")
                .Must(date => date >= DateTime.UtcNow).WithMessage("The due date cannot be in the past.");

            RuleFor(task => task.Status)
                .NotNull().WithMessage("The status is required.");

            RuleFor(task => task.ProjectId)
                .NotNull().WithMessage("The project ID is required.");
        }
    }
}