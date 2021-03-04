

using Microsoft.AspNetCore.Identity;

namespace StudiePlanner.Shared.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
