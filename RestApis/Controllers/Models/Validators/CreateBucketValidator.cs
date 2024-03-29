﻿
using FluentValidation;

namespace CSharp_intro_1.Models.Validators
{
    public class CreateBucketValidator: AbstractValidator<CreateBucketDto>
    {
        public CreateBucketValidator() {
            RuleFor(bucket => bucket.Title).NotEmpty().Length(5, 20).WithMessage("Please specify bucket name with minumum of 5 characters");
        }
    }
}
