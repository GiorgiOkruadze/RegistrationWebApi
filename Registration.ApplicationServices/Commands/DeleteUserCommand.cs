using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.BusinessLogicLayer.Commands
{
    public class DeleteUserCommand:IRequest<bool>
    {
        public int UserId { get; set; }
    }
}
