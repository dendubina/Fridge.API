using System.Collections.Generic;
using System.Threading.Tasks;
using FridgeManager.ReportAzureFunction.Models;

namespace FridgeManager.ReportAzureFunction.Services.Interfaces
{
    internal interface IReportService
    {
        Task SendReportAsync(Owner user, IEnumerable<Fridge> userFridges);
    }
}
