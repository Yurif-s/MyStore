using Microsoft.AspNetCore.Identity;

namespace MyStore.Infrastructure.Identity;

public class RoleSeeder
{
    public static async Task SeedAsync(RoleManager<IdentityRole> roleManager)
    {
        string[] roles = [Roles.Admin, Roles.Customer];

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}
