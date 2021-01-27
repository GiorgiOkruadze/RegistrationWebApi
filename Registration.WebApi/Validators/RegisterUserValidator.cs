using FluentValidation;
using Registration.WebApi.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.WebApi.Validators
{
    public class RegisterUserValidator:AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidator()
        {
            RuleFor(o => o.Email)
                .NotEmpty()
                .Must(o => o.Contains("@"));

            RuleFor(o => o.UserName)
            .NotEmpty()
            .Matches("^[a-zA-Z]*$");

            RuleFor(o => o.Password)
            .NotEmpty()
            .Matches(@"^([a-zA-Z0-9]+)$");

            RuleFor(o => o.RemunerationPerMonthe)
                .GreaterThan(0)
                .When(o => o.IsEmployed);
        }
    }
}
