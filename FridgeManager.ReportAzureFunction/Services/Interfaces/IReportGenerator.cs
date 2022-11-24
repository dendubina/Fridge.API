using System.Collections.Generic;
using System.IO;
using FridgeManager.ReportAzureFunction.Models;

namespace FridgeManager.ReportAzureFunction.Services.Interfaces
{
    internal interface IReportGenerator
    {
        Stream GenerateReport(User user, IEnumerable<Fridge> fridges);
    }
}
