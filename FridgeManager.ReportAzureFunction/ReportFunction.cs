using System.Linq;
using System.Threading.Tasks;
using FridgeManager.ReportAzureFunction.Models;
using FridgeManager.ReportAzureFunction.Services.Interfaces;
using Microsoft.Azure.WebJobs;

namespace FridgeManager.ReportAzureFunction;

internal class ReportFunction
{
    private readonly IUserService _userService;
    private readonly IReportService _reportService;
    private readonly IFridgeService _fridgeService;

    public ReportFunction(IUserService userService, IReportService reportService, IFridgeService fridgeService)
    {
        _userService = userService;
        _reportService = reportService;
        _fridgeService = fridgeService;
    }

    [FunctionName("ReportFunction")]
    public async Task RunAsync([TimerTrigger("0 0 * * 0", RunOnStartup = true)] TimerInfo myTimer)
    {
        var users = await _userService.GetAllUsersAsync();

        foreach (var user in users.Where(x => x.EmailConfirmed))
        {
            var result = await _fridgeService.GetUserFridges(user);
            var userFridges = result as Fridge[] ?? result.ToArray();

            if (userFridges.Any())
            {
                await _reportService.SendReportAsync(user, userFridges);
            }
        }
    }
}