using System.Collections.Generic;
using System.Threading.Tasks;
using ReportAzureFunction.Models;

namespace ReportAzureFunction.Services.Interfaces
{
    internal interface IFridgeService
    {
        Task<IEnumerable<Fridge>> GetFridgesForReport();
    }
}
