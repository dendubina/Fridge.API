using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AuthService.EF.Constants;
using AuthService.Models.DTO;
using AuthService.Models.Request;

namespace AuthService.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserToReturn> FindByIdAsync(Guid userId);

        Task<IEnumerable<UserToReturn>> GetAllAsync(UserRequestParameters parameters);

        Task ChangeStatusAsync(Guid userId, UserStatus status);

        Task AddRoleAsync(Guid userId, RoleNames role);

        Task RemoveRoleAsync(Guid userId, RoleNames role);

        Task UpdateUserAsync(UserToUpdate user);
    }
}
