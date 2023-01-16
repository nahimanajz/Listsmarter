
using FluentValidation;

namespace CSharp_intro_1.Models.Validators
{
    public class PersonDtoValidator: AbstractValidator<CreatePersonDto>
    {
        public PersonDtoValidator()
        {
            RuleFor(person => person.FirstName).NotEmpty().WithMessage("Please specify FirstName").MinimumLength(2).WithMessage("Please enter atleast two characters")
                ;
            RuleFor(person => person.LastName).NotEmpty().WithMessage("Please specify LastName");

        }
    }
}
