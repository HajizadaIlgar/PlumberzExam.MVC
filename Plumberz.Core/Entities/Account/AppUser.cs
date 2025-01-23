using Microsoft.AspNetCore.Identity;

namespace Plumberz.Core.Entities.Account
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string? ProfileImageUrl { get; set; }
    }
}
