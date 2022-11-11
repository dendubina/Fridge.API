using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FridgeManager.AuthMicroService.EF.Constants;
using FridgeManager.AuthMicroService.EF.Entities;
using FridgeManager.AuthMicroService.Models.DTO;
using FridgeManager.AuthMicroService.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FridgeManager.AuthMicroService.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
            => _userManager = userManager;

        public Task<UserToReturn> FindByIdAsync(Guid userId)
        {
            var query = _userManager.Users
                .Where(x => x.Id.Equals(userId));

            return SelectUserToReturn(query).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UserToReturn>> GetAllAsync()
            => await SelectUserToReturn(_userManager.Users).ToListAsync();

        public Task BlockUserAsync(Guid userId)
            => ChangeStatusAsync(userId, UserStatus.Blocked);

        public Task UnblockUserAsync(Guid userId)
            => ChangeStatusAsync(userId, UserStatus.Active);

        public async Task UpdateUserAsync(UserToUpdate user)
        {
            var entityUser = await _userManager.FindByIdAsync(user.Id.ToString());

            entityUser.UserName = user.UserName;
            entityUser.Email = user.Email;

            await _userManager.UpdateAsync(entityUser);
        }

        private async Task ChangeStatusAsync(Guid userId, UserStatus status)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            user.Status = status;

            await _userManager.UpdateAsync(user);
        }

        private static IQueryable<UserToReturn> SelectUserToReturn(IQueryable<ApplicationUser> query)
            => query.Select(user => new UserToReturn
            {
                UserName = user.UserName,
                Email = user.Email,
                Status = user.Status,
                Roles = user.UserRoles.Select(x => x.Role.Name),
            });
    }
}
