using Microsoft.AspNetCore.Identity;
using Registration.DomainCore.Services.Abstractions;
using Registration.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Registration.DomainCore.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager = default;
        private readonly SignInManager<User> _signInManager = default;

        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> ChangeGeneralInformation(int userId, UserInformation info)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            user.GeneralInformation = info;
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> LogIn(LogInUser item)
        {
            var result = await _signInManager.PasswordSignInAsync(item.Email, item.Password, item.Remember, false);
            return result.Succeeded;
        }

        public async Task<bool> Registration(User item,string password)
        {
            var result = await _userManager.CreateAsync(item, password);
            return result.Succeeded;
        }
    }
}
