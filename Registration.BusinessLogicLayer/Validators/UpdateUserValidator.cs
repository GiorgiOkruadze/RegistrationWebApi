using FluentValidation;
using Registration.BusinessLogicLayer.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.BusinessLogicLayer.Validators
{
    public class UpdateUserValidator: AbstractValidator<UpdateUserInfoCommand>
    {
        public UpdateUserValidator()
        {
            RuleFor(o => o.UserId)
                .NotEmpty()
                .NotEqual(0);

            RuleFor(o => o.PersonalNumber)
               .NotEmpty()
               .Matches(@"^[0-9]+$");

            RuleFor(o => o.RemunerationPerMonthe)
                .GreaterThan(0)
                .When(o => o.IsEmployed);
        }
    }
}
