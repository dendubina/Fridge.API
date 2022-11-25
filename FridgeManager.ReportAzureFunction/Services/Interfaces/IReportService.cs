using System.Collections.Generic;
using System.Threading.Tasks;
using FridgeManager.ReportAzureFunction.Models;

namespace FridgeManager.ReportAzureFunction.Services.Interfaces
{
    internal interface IReportService
    {
        Task SendReportAsync(User user, IEnumerable<Fridge> userFridges);
    }
}
