using ITechArt.FlightBookingsAPI.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace ITechArt.FlightBookingsAPI.Web.Utils;

public static class DbInitializer
{
    public static async Task SeedRoles(RoleManager<IdentityRole<Guid>> roleManager)
    {
        if (await roleManager.FindByNameAsync("Admin") is null)
        {
            var adminRole = new IdentityRole<Guid>
            {
                Name = "Admin",
                NormalizedName = "Admin".ToUpper()
            };
            var result = await roleManager.CreateAsync(adminRole);
        }
        
        if (await roleManager.FindByNameAsync("User") == null)
        {
            var userRole = new IdentityRole<Guid>
            {
                Name = "User",
                NormalizedName = "User".ToUpper()
            };
            var result = await roleManager.CreateAsync(userRole);
        }
    }

    public static async Task SeedUsers(UserManager<User> userManager, string adminPass)
    {
        if (await userManager.FindByNameAsync("admin") is null)
        {
            var user = new User
            {
                UserName = "admin",
                Email = "admin@gmail.com"
            };

            var result = await userManager.CreateAsync(user, adminPass);
            if (result.Succeeded)
            {
                result = await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}