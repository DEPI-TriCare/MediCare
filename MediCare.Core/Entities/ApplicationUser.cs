using Microsoft.AspNetCore.Identity;

namespace MediCare.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}
