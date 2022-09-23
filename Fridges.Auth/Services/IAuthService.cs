using System.Threading.Tasks;
using Fridges.Auth.Models;

namespace Fridges.Auth.Services
{
    public interface IAuthService
    {
        Task<UserProfile> SignIn(SignInModel userData);

        Task<UserProfile> SignUp(SignUpModel userData);
    }
}
