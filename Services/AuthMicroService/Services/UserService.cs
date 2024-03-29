﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthService.EF.Constants;
using AuthService.EF.Entities;
using AuthService.Models.DTO;
using AuthService.Models.Request;
using AuthService.Services.Interfaces;
using FridgeManager.Shared.Models;
using FridgeManager.Shared.Models.Constants;
using MassTransit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        readonly IPublishEndpoint _publishEndpoint;

        public UserService(UserManager<ApplicationUser> userManager, IPublishEndpoint publishEndpoint)
        {
            _userManager = userManager;
            _publishEndpoint = publishEndpoint;
        }

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
            entityUser.MailingConfirmed = user.MailingConfirmed;

            var result = await _userManager.UpdateAsync(entityUser);

            if (!result.Succeeded)
            {
                var message = string.Join(Environment.NewLine, result.Errors.Select(x => x.Description));

                throw new InvalidOperationException(message);
            }

            await _publishEndpoint.Publish(CreateSharedUser(entityUser));
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

        private SharedUser CreateSharedUser(ApplicationUser user)
            => new()
            {
                Id = user.Id,
                UserName = user.UserName,
                EmailConfirmed = user.EmailConfirmed,
                Email = user.Email,
                MailingConfirmed = user.MailingConfirmed,
                ActionType = ActionType.Update,
            };
    }
}
