using Registration.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Registration.DomainCore.Services.Abstractions
{
    public interface IUserRepository
    {
        Task<bool> RegistrationAsync(User item,string password);
        Task<bool> LogInAsync(LogInUser item);
        Task<bool> DeleteUserAsync(int id);
        Task<bool> ChangeGeneralInformationAsync(int userId, UserInformation info);
    }
}
