using Microsoft.AspNetCore.Identity;

namespace MyStore.Infrastructure.Identity;

internal class ApplicationUser : IdentityUser
{
    public string Fullname { get; set; } = string.Empty;
}
