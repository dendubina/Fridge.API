using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FridgeManager.AuthMicroService.EF.Constants;
using FridgeManager.AuthMicroService.EF.Entities;
using FridgeManager.AuthMicroService.Models.DTO;
using FridgeManager.AuthMicroService.Models.Request;
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

        public async Task<IEnumerable<UserToReturn>> GetAllAsync(UserRequestParameters parameters)
        {
            var query = _userManager.Users;

            if (parameters.EmailConfirmed)
            {
                query = query.Where(x => x.EmailConfirmed);
            }

            if (parameters.MailingConfirmed)
            {
                query = query.Where(x => x.MailingConfirmed);
            }

            return await SelectUserToReturn(query).ToListAsync();
        }

        public async Task ChangeStatusAsync(Guid userId, UserStatus status)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            user.Status = status;

            await _userManager.UpdateAsync(user);
        }

        public async Task AddRoleAsync(Guid userId, RoleNames role)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            await _userManager.AddToRoleAsync(user, role.ToString());
        }

        public async Task RemoveRoleAsync(Guid userId, RoleNames role)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            await _userManager.RemoveFromRoleAsync(user, role.ToString());
        }

        public async Task UpdateUserAsync(UserToUpdate user)
        {
            var entityUser = await _userManager.FindByIdAsync(user.Id.ToString());

            entityUser.UserName = user.UserName;
            entityUser.Email = user.Email;

            var result = await _userManager.UpdateAsync(entityUser);

            if (!result.Succeeded)
            {
                var message = string.Join(Environment.NewLine, result.Errors.Select(x => x.Description));

                throw new InvalidOperationException(message);
            }
        }

        private static IQueryable<UserToReturn> SelectUserToReturn(IQueryable<ApplicationUser> query)
            => query.Select(user => new UserToReturn
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Status = user.Status,
                EmailConfirmed = user.EmailConfirmed,
                MailingConfirmed = user.MailingConfirmed,
                Roles = user.UserRoles.Select(x => x.Role.Name),
            });
    }
}
