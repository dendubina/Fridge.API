using System.Threading.Tasks;

namespace FridgeManager.ReportAzureFunction.Services.Interfaces
{
    internal interface IAccessTokenAccessor
    {
        Task<string> GetAccessTokenAsync();
    }
}
