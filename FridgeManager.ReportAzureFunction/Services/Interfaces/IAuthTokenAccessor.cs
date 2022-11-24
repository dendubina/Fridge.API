using System.Threading.Tasks;

namespace FridgeManager.ReportAzureFunction.Services.Interfaces
{
    internal interface IAuthTokenAccessor
    {
        Task<string> GetAccessTokenAsync();
    }
}
