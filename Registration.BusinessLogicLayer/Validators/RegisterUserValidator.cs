using FluentValidation;
using Registration.BusinessLogicLayer.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.BusinessLogicLayer.Validators
{
    public class RegisterUserValidator:AbstractValidator<RegisterUserCommand>
    {
        [Obsolete]
        public RegisterUserValidator()
        {
            RuleFor(o => o.Email)
                .NotEmpty()
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.Net4xRegex);

            RuleFor(o => o.UserName)
            .NotEmpty()
            .Matches("^[a-zA-Z ]*$");

            RuleFor(o => o.PersonalNumber)
                .Length(11)
                .Matches(@"^[0-9]+$");

            RuleFor(o => o.Password)
            .NotEmpty()
            .MinimumLength(3)
            .Matches(@"^([a-zA-Z0-9]+)$")
            .Matches(o => o.PasswordConfirm);

            RuleFor(o => o.RemunerationPerMonthe)
                .GreaterThan(0)
                .When(o => o.IsEmployed);
        }
    }
}
