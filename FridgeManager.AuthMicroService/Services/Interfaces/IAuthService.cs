using System.Threading.Tasks;
using AuthService.Models;
using AuthService.Models.Request;

namespace AuthService.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UserProfile> SignInAsync(SignInModel userData);

        Task<UserProfile> SignUpAsync(SignUpModel userData);

        Task ConfirmEmailAsync(EmailConfirmModel data);
    }
}
