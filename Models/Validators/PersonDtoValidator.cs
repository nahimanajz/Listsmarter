
using FluentValidation;

namespace CSharp_intro_1.Models.Validators
{
    public class PersonDtoValidator: AbstractValidator<PersonDto>
    {
        public PersonDtoValidator()
        {
            RuleFor(person => person.FirstName).NotEmpty().WithMessage("Please specify FirstName").MinimumLength(2).WithMessage("Please enter atleast two characters")
                ;
            RuleFor(person => person.LastName).NotEmpty().WithMessage("Please specify LaststName");

        }
    }
}
