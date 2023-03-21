using System.Collections.Generic;
using ReportAzureFunction.Models;

namespace ReportAzureFunction.Services.Interfaces
{
    internal interface IReportGenerator
    {
         Report GenerateReport(Owner user, IEnumerable<Fridge> fridges);
    }
}
