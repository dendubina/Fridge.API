using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FridgeManager.AuthMicroService.EF.Constants;
using FridgeManager.AuthMicroService.Models.DTO;

namespace FridgeManager.AuthMicroService.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserToReturn> FindByIdAsync(Guid userId);

        Task<IEnumerable<UserToReturn>> GetAllAsync();

        Task ChangeStatusAsync(Guid userId, UserStatus status);

        Task AddRoleAsync(Guid userId, RoleNames role);

        Task RemoveRoleAsync(Guid userId, RoleNames role);

        Task UpdateUserAsync(UserToUpdate user);
    }
}
