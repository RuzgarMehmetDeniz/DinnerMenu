using DinnerMenuPostgreSQL.Context;
using Microsoft.AspNetCore.Mvc;

namespace DinnerMenuPostgreSQL.Controllers
{
    public class AdminLayoutController : Controller
    {
        private readonly AppDbContext _context;

        public AdminLayoutController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
           ViewBag.categorycount = _context.Categories.Count();
            return View();
        }
    }
}
