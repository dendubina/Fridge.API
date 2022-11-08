using System.Threading.Tasks;
using FridgeManager.AuthMicroService.Models;

namespace FridgeManager.AuthMicroService.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserProfile> SignIn(SignInModel userData);

        Task<UserProfile> SignUp(SignUpModel userData);
    }
}
