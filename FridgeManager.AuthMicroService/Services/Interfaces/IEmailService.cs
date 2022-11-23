using System;
using System.Threading.Tasks;

namespace FridgeManager.AuthMicroService.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendConfirmationEmailAsync(string receiverEmail, Guid userId, string token);
    }
}
