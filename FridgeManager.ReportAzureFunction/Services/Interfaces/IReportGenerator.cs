using System.Collections.Generic;
using FridgeManager.ReportAzureFunction.Models;

namespace FridgeManager.ReportAzureFunction.Services.Interfaces
{
    internal interface IReportGenerator
    {
         Report GenerateReport(Owner user, IEnumerable<Fridge> fridges);
    }
}
