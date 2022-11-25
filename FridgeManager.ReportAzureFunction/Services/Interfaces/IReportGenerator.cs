using System.Collections.Generic;
using FridgeManager.ReportAzureFunction.Models;

namespace FridgeManager.ReportAzureFunction.Services.Interfaces
{
    internal interface IReportGenerator
    {
         Report GenerateReport(User user, IEnumerable<Fridge> fridges);
    }
}
