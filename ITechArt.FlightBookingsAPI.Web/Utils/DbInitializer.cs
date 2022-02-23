using ITechArt.FlightBookingsAPI.Domain.Constants;
using ITechArt.FlightBookingsAPI.Domain.Models;
using ITechArt.FlightBookingsAPI.Infrastructure.Migrations;
using Microsoft.AspNetCore.Identity;

namespace ITechArt.FlightBookingsAPI.Web.Utils;

public static class DbInitializer
{
    public static async Task SeedRoles(RoleManager<IdentityRole<Guid>> roleManager)
    {
        if (await roleManager.FindByNameAsync(IdentityRoles.AdminRole) is null)
        {
            var adminRole = new IdentityRole<Guid>
            {
                Name = IdentityRoles.AdminRole,
                NormalizedName = IdentityRoles.AdminRole.ToUpper()
            };
            var result = await roleManager.CreateAsync(adminRole);
        }
        
        if (await roleManager.FindByNameAsync(IdentityRoles.UserRole) == null)
        {
            var userRole = new IdentityRole<Guid>
            {
                Name = IdentityRoles.UserRole,
                NormalizedName = IdentityRoles.UserRole.ToUpper()
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
                result = await userManager.AddToRoleAsync(user, IdentityRoles.AdminRole);
            }
        }
    }
}