using FluentValidation;
using Registration.BusinessLogicLayer.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.BusinessLogicLayer.Validators
{
    public class LogInUserValidator : AbstractValidator<LogInCommand>
    {
        [Obsolete]
        public LogInUserValidator()
        {
            RuleFor(o => o.Email)
                .NotEmpty()
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.Net4xRegex);

            RuleFor(o => o.Password)
                .NotEmpty()
                .MinimumLength(3)
                .Matches(@"^([a-zA-Z0-9]+)$");
        }
    }
}
