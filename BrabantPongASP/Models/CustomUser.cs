using Microsoft.AspNetCore.Identity;

namespace BrabantPongASP.Models
{
    public class CustomUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}
