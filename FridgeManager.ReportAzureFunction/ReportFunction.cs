using System;
using System.Linq;
using System.Threading.Tasks;
using FridgeManager.ReportAzureFunction.Services.Interfaces;
using Microsoft.Azure.WebJobs;

namespace FridgeManager.ReportAzureFunction;

internal class ReportFunction
{
    private readonly IReportService _reportService;
    private readonly IFridgeService _fridgeService;

    public ReportFunction(IReportService reportService, IFridgeService fridgeService)
    {
        _reportService = reportService;
        _fridgeService = fridgeService;
    }

    [FunctionName("ReportFunction")]
    public async Task RunAsync([TimerTrigger("0 0 * * 0", RunOnStartup = true)] TimerInfo myTimer)
    {
        var fridges = await _fridgeService.GetFridgesForReport();
       
        foreach (var group in fridges.GroupBy(x => x.Owner))
        {
           // Console.WriteLine($"{group.Key.Email}: Fridges: {group.Count()}");
            await _reportService.SendReportAsync(group.Key, group);
        }
    }
}