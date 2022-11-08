using System;
using System.Threading.Tasks;
using FridgeManager.AuthMicroService.EF.Constants;
using FridgeManager.AuthMicroService.EF.Entities;
using FridgeManager.AuthMicroService.Models;
using FridgeManager.AuthMicroService.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace FridgeManager.AuthMicroService.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApplicationUser> GetUserAsync(Guid userId)
            => await _userManager.FindByIdAsync(userId.ToString());

        public Task BlockUserAsync(ApplicationUser user)
            => ChangeStatusAsync(user, UserStatuses.Blocked);

        public Task UnblockUserAsync(ApplicationUser user)
            => ChangeStatusAsync(user, UserStatuses.Active);

        public Task UpdateUserAsync(UserToUpdate user)
        {
            throw new NotImplementedException();
        }

        private async Task ChangeStatusAsync(ApplicationUser user, UserStatuses status)
        {
            user.Status = status;

            await _userManager.UpdateAsync(user);
        }
    }
}
