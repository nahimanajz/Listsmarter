
using FluentValidation;

namespace CSharp_intro_1.Models.Validators
{
    public class CreateTaskValidator : AbstractValidator<CreateTaskDto>
    {
        public CreateTaskValidator()
        {
            RuleFor(task => task.Title).Length(5, 20).NotNull().NotEmpty().WithMessage("Please add Title");
            RuleFor(task => task.Description).MaximumLength(100).WithMessage("Description should not exceed 100 characters");
            RuleFor(task => task.Person).NotEmpty().WithMessage("Person should not be empty");
            RuleFor(task => task.Bucket).NotEmpty().WithMessage("Bucket should not be empty");

        }
    }
}
