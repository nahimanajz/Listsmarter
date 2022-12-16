﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CSharp_intro_1.Models.Validators
{
    public class BucketDtoValidator: AbstractValidator<BucketDto>
    {
        public BucketDtoValidator() {
            RuleFor(bucket => bucket.Title).NotEmpty().Length(3, 20).WithMessage("Please specify name with minumum of 5 characters");


        }
    }
}
