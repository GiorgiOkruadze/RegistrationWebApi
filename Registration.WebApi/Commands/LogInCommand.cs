using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.WebApi.Commands
{
    public class LogInCommand:IRequest<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Remember { get; set; }
        public string ReturnUrl { get; set; }
    }
}
