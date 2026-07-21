using Microsoft.AspNetCore.Mvc;

namespace DinnerMenuPostgreSQL.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
