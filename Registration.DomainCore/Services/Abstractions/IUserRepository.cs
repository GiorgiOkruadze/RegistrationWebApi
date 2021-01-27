using Registration.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Registration.DomainCore.Services.Abstractions
{
    public interface IUserRepository
    {
        Task<bool> Registration(User item,string password);
        Task<bool> LogIn(LogInUser item);
        Task<bool> DeleteUser(int id);
        Task<bool> ChangeGeneralInformation(int userId, UserInformation info);
    }
}
