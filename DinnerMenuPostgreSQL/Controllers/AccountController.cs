using DinnerMenuPostgreSQL.Context;
using DinnerMenuPostgreSQL.Dtos.AccountDtos;
using DinnerMenuPostgreSQL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DinnerMenuPostgreSQL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        // ── KAYIT (sadece müşteri kaydı — müşteri tarafı) ──
        [HttpGet]
        public IActionResult Register() => View(new RegisterViewModel());

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Müşteri");
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("MyAccount");
            }

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return View(model);
        }

        // ── GİRİŞ ──
        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            if (!ModelState.IsValid) return View(model);

            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                // 1. Eğer açık bir returnUrl varsa (örn: yetkisiz sayfaya girmeye çalışıp login'e atıldıysa) oraya git
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);

                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null) return RedirectToAction("Index", "Home");

                var roles = await _userManager.GetRolesAsync(user);

                // 2. Dinamik olarak gidilecek rotayı belirle
                var (controller, action) = GetRedirectRouteForRoles(roles);
                return RedirectToAction(action, controller);
            }

            ModelState.AddModelError("", "E-posta veya şifre hatalı.");
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Menu");
        }

        [HttpGet]
        public IActionResult AccessDenied() => View();

        // ── HESABIM (müşteri tarafı) ──
        [Authorize(Roles = "Müşteri")]
        public async Task<IActionResult> MyAccount()
        {
            var userId = _userManager.GetUserId(User);

            var reservations = await _context.Reservations
                .Where(r => r.ApplicationUserId == userId)
                .OrderByDescending(r => r.ReservationDate)
                .ToListAsync();

            var reviews = await _context.Reviews
                .Include(r => r.Product)
                .Where(r => r.ApplicationUserId == userId)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            ViewBag.Reservations = reservations;
            ViewBag.Reviews = reviews;

            return View();
        }
        private (string Controller, string Action) GetRedirectRouteForRoles(IList<string> roles)
        {
            // Öncelik sırasına göre dinamik eşleştirme
            // (Bir kullanıcının birden fazla rolü olabilir, en yetkili rolü baz alıyoruz)
            if (roles.Contains("Admin") || roles.Contains("Müdür"))
            {
                return ("Dashboard", "Index"); // Admin ve Müdür -> Yönetici Paneli
            }

            if (roles.Contains("Şef") || roles.Contains("Aşçı"))
            {
                return ("Kitchen", "Orders"); // Mutfak Ekibi -> Mutfak/Sipariş Ekranı
            }

            if (roles.Contains("Garson") || roles.Contains("Komi"))
            {
                return ("Pos", "Tables"); // Saha Ekibi -> Masa/Sipariş Ekranı
            }

            if (roles.Contains("Müşteri"))
            {
                return ("Account", "MyAccount"); // Müşteri -> Profil Sayfası
            }

            // Tanımlanmamış veya varsayılan rol için fallback
            return ("Menu", "Index");
        }
        // 2. Sayfa Bulunamadı (404)
        [HttpGet]
        public IActionResult PageNotFound() => View();

        // 3. Sunucu Hatası (500)
        [HttpGet]
        public IActionResult Error500() => View();

        // 4. HTTP Durum Kodlarını Yakalayan Yönlendirici (Middleware burayı çağırır)
        [Route("Account/HandleError/{code}")]
        public IActionResult HandleError(int code)
        {
            if (code == 404)
            {
                return RedirectToAction("PageNotFound");
            }
            if (code == 401 || code == 403)
            {
                return RedirectToAction("AccessDenied");
            }

            return RedirectToAction("Error500");
        }
    }
}