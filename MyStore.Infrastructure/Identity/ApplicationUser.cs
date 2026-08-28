using Microsoft.AspNetCore.Identity;

namespace MyStore.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string Fullname { get; set; } = string.Empty;
}
