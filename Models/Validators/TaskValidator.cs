using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CSharp_intro_1.Models.Validators
{
    public class TaskValidator: AbstractValidator<TaskDto>
    {
        public TaskValidator() {
            RuleFor(task => task.Title).Length(5, 20).WithMessage("Consider adding short descriptive title");
           RuleFor(task => task.Description).NotEmpty();
           RuleFor(task => task.Assignee).NotEmpty();
           RuleFor(task => task.Bucket).NotEmpty();

        }
    }
}
