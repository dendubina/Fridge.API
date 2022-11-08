using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FridgeManager.AuthMicroService.EF.Entities;
using FridgeManager.AuthMicroService.Models;

namespace FridgeManager.AuthMicroService.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<ApplicationUser>> GetAllAsync();

        Task<ApplicationUser> GetUserAsync(Guid userId);

        Task BlockUserAsync(ApplicationUser user);

        Task UnblockUserAsync(ApplicationUser user);

        Task UpdateUserAsync(UserToUpdate user);
    }
}
