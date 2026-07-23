using DinnerMenuPostgreSQL.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DinnerMenuPostgreSQL.Controllers
{
    public class AdminLayoutController : Controller
    {
        private readonly AppDbContext _context;

        public AdminLayoutController(AppDbContext context)
        {
            _context = context;
        }

        public  IActionResult Index()
        {
            return View();
        }
    }
}
