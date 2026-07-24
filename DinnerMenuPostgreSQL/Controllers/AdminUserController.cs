using DinnerMenuPostgreSQL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DinnerMenuPostgreSQL.Controllers
{
        public class AdminUserController : Controller
        {
            private readonly UserManager<ApplicationUser> _userManager;

            public AdminUserController(UserManager<ApplicationUser> userManager)
            {
                _userManager = userManager;
            }

            public async Task<IActionResult> UserList()
            {
                var values = await _userManager.Users.ToListAsync();
                return View(values);
            }
        }
    }
