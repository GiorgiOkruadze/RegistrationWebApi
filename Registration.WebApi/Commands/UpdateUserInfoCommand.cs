using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.WebApi.Commands
{
    public class UpdateUserInfoCommand:IRequest<bool>
    {
        public int UserId { get; set; }
        public string PersonalNumber { get; set; }
        public bool IsMarried { get; set; }
        public bool IsEmployed { get; set; }
        public double RemunerationPerMonthe { get; set; }
        public string Address { get; set; }

    }
}
