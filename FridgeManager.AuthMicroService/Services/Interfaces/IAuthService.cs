using System.Threading.Tasks;
using FridgeManager.AuthMicroService.Models;
using FridgeManager.AuthMicroService.Models.Request;

namespace FridgeManager.AuthMicroService.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserProfile> SignInAsync(SignInModel userData);

        Task<UserProfile> SignUpAsync(SignUpModel userData);

        Task ConfirmEmailAsync(EmailConfirmModel data);
    }
}
