using FluentValidation;
using Registration.WebApi.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.WebApi.Validators
{
    public class UpdateUserValidator: AbstractValidator<UpdateUserInfoCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(o => o.UserId)
                .NotEmpty()
                .NotEqual(0);

            RuleFor(o => o.RemunerationPerMonthe)
                .GreaterThan(0)
                .When(o => o.IsEmployed);
        }
    }
}
