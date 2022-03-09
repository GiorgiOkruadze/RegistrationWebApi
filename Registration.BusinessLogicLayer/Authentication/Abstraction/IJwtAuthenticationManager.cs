using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.BusinessLogicLayer.Authentication.Abstraction
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(int userId, string email);
    }
}
