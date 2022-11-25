using System.Collections.Generic;
using System.Threading.Tasks;
using FridgeManager.ReportAzureFunction.Models;

namespace FridgeManager.ReportAzureFunction.Services.Interfaces
{
    internal interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
