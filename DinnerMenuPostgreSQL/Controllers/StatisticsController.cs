using Microsoft.AspNetCore.Mvc;

namespace DinnerMenuPostgreSQL.Controllers
{
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
