using Microsoft.AspNetCore.Identity;

namespace WeAreMadeToHeal
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}
