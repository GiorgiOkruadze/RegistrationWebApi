using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Registration.DataAccessLayer.DB;
using Registration.DataAccessLayer.Services.Abstractions;
using Registration.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Registration.DataAccessLayer.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager = default;
        private readonly ApplicationDbContext _dbContext = default;
        private readonly SignInManager<User> _signInManager = default;

        public UserRepository(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationDbContext db)
        {
            _dbContext = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> ChangeGeneralInformationAsync(int userId, UserInformation info)
        {
            var information = await _dbContext.UserInformations.AsNoTracking().FirstOrDefaultAsync(o => o.UserId == userId);
            info.Id = information.Id;
            _dbContext.Update(info);
            return await _dbContext.SaveChangesAsync() >= 0;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<bool> LogInAsync(LogInUser item)
        {
            var user = await _userManager.FindByEmailAsync(item.Email);
            var result = await _signInManager.PasswordSignInAsync(user, item.Password, item.Remember, false);
            return result.Succeeded;
        }

        public async Task<bool> RegistrationAsync(User item,string password)
        {
            var result = await _userManager.CreateAsync(item, password);
            return result.Succeeded;
        }
    }
}
