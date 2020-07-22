using System;
using System.Linq;
using System.Threading.Tasks;

using Application.Common.Interfaces;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Identity {

    public class UserService : IUserService {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager) {
            _userManager = userManager;
        }


        public async Task<string> GetUserNameAsync(Guid userId) {
            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

            return user.UserName;
        }


        public async Task<(IIdentityResult result, Guid userId)> CreateUserAsync(string email, string password) {
            var user = new ApplicationUser {
                UserName = email,
                Email = email,
            };

            var result = await _userManager.CreateAsync(user, password);

            return (result.ToApplicationResult(), user.Id);
        }


        public async Task<IIdentityResult> DeleteUserAsync(Guid userId) {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            if (user != null) {
                return await DeleteUserAsync(user);
            }

            return Application.Common.Models.IdentityResult.Success();
        }


        public async Task<IIdentityResult> DeleteUserAsync(ApplicationUser user) {
            var result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }
    }
}
