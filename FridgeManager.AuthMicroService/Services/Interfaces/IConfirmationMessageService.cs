using System.Threading.Tasks;
using FridgeManager.AuthMicroService.EF.Entities;

namespace FridgeManager.AuthMicroService.Services.Interfaces
{
    public interface IConfirmationMessageService
    {
        Task SendConfirmationMessageAsync(ApplicationUser user);
    }
}
