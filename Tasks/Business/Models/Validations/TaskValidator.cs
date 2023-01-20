
using FluentValidation;

namespace CSharp_intro_1.Models.Validators
{
    public class TaskValidator : AbstractValidator<TaskDto>
    {
        public TaskValidator()
        {
            RuleFor(task => task.Title).Length(5, 20).NotNull().NotEmpty().WithMessage("Please add Title");
            RuleFor(task => task.Description).MaximumLength(100).WithMessage("Description should not exceed 100 characters");
            RuleFor(task => task.Assignee).NotEmpty().WithMessage("Assignee should not be empty");
            RuleFor(task => task.Bucket).NotEmpty().WithMessage("Bucket should not be empty");

        }
    }
}
