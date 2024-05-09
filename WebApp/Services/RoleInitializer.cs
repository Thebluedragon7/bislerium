using Microsoft.AspNetCore.Identity;

namespace WebApp.Services;

public static class RoleInitializer
{
    public static async Task InitializeAsync(RoleManager<IdentityRole> roleManager)
    {
        string[] roles = new string[] { "Admin", "Blogger", "Surfer" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }
}