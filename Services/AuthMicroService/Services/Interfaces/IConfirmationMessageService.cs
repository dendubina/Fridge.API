using System.Threading.Tasks;
using AuthService.EF.Entities;

namespace AuthService.Services.Interfaces
{
    public interface IConfirmationMessageService
    {
        Task SendConfirmationMessageAsync(ApplicationUser user);
    }
}
