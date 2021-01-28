using FluentValidation;
using Registration.BusinessLogicLayer.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.BusinessLogicLayer.Validators
{
    public class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserValidator()
        {
            RuleFor(o => o.UserId)
                .NotEmpty()
                .NotEqual(0);
        }
    }
}
