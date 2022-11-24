using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using FridgeManager.ReportAzureFunction.Models.Options;
using FridgeManager.ReportAzureFunction.Services.Interfaces;
using Microsoft.Azure.WebJobs;

namespace FridgeManager.ReportAzureFunction
{
    internal class ReportFunction
    {
        private readonly IUserService _userService;
        private readonly IReportService _reportService;

        public ReportFunction(IUserService userService, IReportService reportService)
        {
            _userService = userService;
            _reportService = reportService;
        }

        [FunctionName("ReportFunction")]
        public async Task RunAsync([TimerTrigger("0 0 * * 0", RunOnStartup = true)] TimerInfo myTimer)
        {
            var users = await _userService.GetAllUsers();

            foreach (var user in users)
            {
                await _reportService.SendReportAsync(user);   
            }
        }
    }
}
