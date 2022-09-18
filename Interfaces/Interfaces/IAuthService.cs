using System.Threading.Tasks;
using Entities.DTO.User;
using Entities.Models;

namespace Contracts.Interfaces
{
    public interface IAuthService
    {
        Task<UserProfile> SignIn(UserSignInDto user);

        Task<UserProfile> SignUp(UserSignUpDto user);
    }
}
