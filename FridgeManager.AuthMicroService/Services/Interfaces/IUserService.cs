using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FridgeManager.AuthMicroService.Models.DTO;

namespace FridgeManager.AuthMicroService.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserToReturn> FindByIdAsync(Guid userId);

        Task<IEnumerable<UserToReturn>> GetAllAsync();

        Task BlockUserAsync(Guid userId);

        Task UnblockUserAsync(Guid userId);

        Task AddAdminAsync(Guid userId);

        Task RemoveAdminAsync(Guid userId);

        Task UpdateUserAsync(UserToUpdate user);
    }
}
