using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;

namespace soruCevapPortali.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
    }
}
