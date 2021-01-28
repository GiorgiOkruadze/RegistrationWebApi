using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.BusinessLogicLayer.Commands
{
    public class RegisterUserCommand:IRequest<bool>
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string PasswordConfirm { get; set; }
        public string PersonalNumber { get; set; }
        public bool IsMarried { get; set; }
        public bool IsEmployed { get; set; }
        public double RemunerationPerMonthe { get; set; }
        public string Address { get; set; }
    }
}
