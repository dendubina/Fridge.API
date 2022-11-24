using System.Collections.Generic;
using System.Threading.Tasks;
using FridgeManager.ReportAzureFunction.Models;

namespace FridgeManager.ReportAzureFunction.Services.Interfaces
{
    internal interface IReportGenerator
    {
        Task GenerateReportAsync(User user, IEnumerable<Fridge> fridges);
    }
}
