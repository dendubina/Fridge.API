using System.Threading.Tasks;
using FridgeManager.ReportAzureFunction.Models;
using FridgeManager.ReportAzureFunction.Services.Interfaces;

namespace FridgeManager.ReportAzureFunction.Services
{
    internal class ReportService : IReportService
    {
        private readonly IReportGenerator _reportGenerator;
        

        public ReportService(IReportGenerator reportGenerator, ISmp)
        {
            _reportGenerator = reportGenerator;
        }

        public async Task SendReportAsync(User user)
        {
            await _reportGenerator.GenerateReportAsync(user, null);
        }
    }
}
