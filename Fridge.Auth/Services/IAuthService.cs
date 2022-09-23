using System.Threading.Tasks;
using Fridge.Auth.Models;

namespace Fridge.Auth.Services
{
    public interface IAuthService
    {
        Task<UserProfile> SignIn(SignInModel userData);

        Task<UserProfile> SignUp(SignUpModel userData);
    }
}
