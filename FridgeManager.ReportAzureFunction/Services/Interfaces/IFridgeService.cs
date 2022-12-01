using System.Collections.Generic;
using System.Threading.Tasks;
using FridgeManager.ReportAzureFunction.Models;

namespace FridgeManager.ReportAzureFunction.Services.Interfaces
{
    internal interface IFridgeService
    {
        Task<IEnumerable<Fridge>> GetFridgesForReport();
    }
}
