using System.Collections.Generic;
using System.Threading.Tasks;
using ReportAzureFunction.Models;

namespace ReportAzureFunction.Services.Interfaces
{
    internal interface IReportService
    {
        Task SendReportAsync(Owner user, IEnumerable<Fridge> userFridges);
    }
}
