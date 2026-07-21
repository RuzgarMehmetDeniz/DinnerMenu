using Microsoft.AspNetCore.Mvc;

namespace DinnerMenuPostgreSQL.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
