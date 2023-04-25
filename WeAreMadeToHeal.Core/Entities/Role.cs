using Microsoft.AspNetCore.Identity;

namespace WeAreMadeToHeal
{
    public class Role : IdentityRole
    {
        public string Name { get; set; }
    }
}
