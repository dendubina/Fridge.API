using System;
using System.Linq;
using System.Threading.Tasks;
using FridgeManager.ReportAzureFunction.Services.Interfaces;
using Microsoft.Azure.WebJobs;

namespace FridgeManager.ReportAzureFunction
{
    internal class ReportFunction
    {
        private readonly IUserService _userService;
        private readonly IReportService _reportService;
        private readonly IAuthTokenAccessor _tokenAccessor;

        public ReportFunction(IUserService userService, IReportService reportService, IAuthTokenAccessor tokenAccessor)
        {
            _userService = userService;
            _reportService = reportService;
            _tokenAccessor = tokenAccessor;
        }

        [FunctionName("ReportFunction")]
        public async Task RunAsync([TimerTrigger("0 0 * * 0", RunOnStartup = true)] TimerInfo myTimer)
        {
            Console.WriteLine(await _tokenAccessor.GetAccessTokenAsync());

            var users = await _userService.GetAllUsers();

            await _reportService.SendReportAsync(users.First(x => x.Email == "awestruck31@mail.ru"));

            /*foreach (var user in users)
            {
                await _reportService.SendReportAsync(user);
            }*/
        }
    }
}
