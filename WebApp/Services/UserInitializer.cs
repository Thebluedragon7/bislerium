using CoreBusiness;
using Microsoft.AspNetCore.Identity;

namespace WebApp.Services;

public static class UserInitializer
{
    public static async Task InitializeAsync(UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        var adminEmail = "admin@admin.com";
        var adminPassword = "Root@123";
        var adminRole = "Admin";

        if (await userManager.FindByEmailAsync(adminEmail) == null)
        {
            var adminUser = new User()
                { UserName = adminEmail, Email = adminEmail, EmailConfirmed = true, FullName = "Admin" };
            var result = await userManager.CreateAsync(adminUser, adminPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(adminUser, adminRole);
            }
        }
    }
}