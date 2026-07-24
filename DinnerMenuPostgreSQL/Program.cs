using DinnerMenuPostgreSQL.Context;
using DinnerMenuPostgreSQL.Data;
using DinnerMenuPostgreSQL.Entities;
using DinnerMenuPostgreSQL.Service.CategoryServices;
using DinnerMenuPostgreSQL.Service.ChartServices;
using DinnerMenuPostgreSQL.Service.DashboardServices;
using DinnerMenuPostgreSQL.Service.OrderServices;
using DinnerMenuPostgreSQL.Service.ProductServices;
using DinnerMenuPostgreSQL.Service.ReservationServices;
using DinnerMenuPostgreSQL.Service.ReviewServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// ── IDENTITY ──
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // Basit şifre kuralları
    options.Password.RequireDigit = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromDays(7);
    options.SlidingExpiration = true;
});

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IChartService, ChartService>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// ── HATA VE DURUM KODU YÖNETİMİ ──
if (!app.Environment.IsDevelopment())
{
    // 500 ve yakalanamayan sunucu hatalarında yönlendirilecek action
    app.UseExceptionHandler("/Account/Error500");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// 404, 401 gibi durum kodlarını dinamik olarak yönlendirir
app.UseStatusCodePagesWithReExecute("/Account/HandleError/{0}");

app.UseAuthentication(); // UseAuthorization'dan ÖNCE olmalı
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// ── ROLLERİ VE ADMIN KULLANICIYI SEED ET ──
using (var scope = app.Services.CreateScope())
{
    await IdentitySeeder.SeedAsync(scope.ServiceProvider);
}

app.Run();