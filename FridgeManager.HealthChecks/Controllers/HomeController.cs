using Microsoft.AspNetCore.Mvc;

namespace FridgeManager.HealthChecks.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return Redirect("/healthchecks-ui");
        }
    }
}
