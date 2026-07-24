using DinnerMenuPostgreSQL.Entities;
using Microsoft.AspNetCore.Identity;

namespace DinnerMenuPostgreSQL.Data
{
    public static class IdentitySeeder
    {
        public static readonly string[] Roles = new[]
        {
            "Admin", "Müdür", "Şef", "Aşçı", "Garson", "Komi", "Müşteri"
        };

        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            foreach (var roleName in Roles)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }
    }
}
