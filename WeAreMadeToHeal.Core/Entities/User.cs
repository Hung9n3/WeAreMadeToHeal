using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using WeAreMadeToHeal.Enums;

namespace WeAreMadeToHeal
{
    public class User : IdentityUser
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; } = DateTime.MinValue;
        public string Username { get; set; }
        public string Password { get; set; }
        public bool EmailConfirmed { get; set; } = false;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool PhoneNumberConfirmed { get; set; } = false;
        public UserRoles Role { get; set; }
        public string Address { get; set; } = string.Empty;
        public Order Order { get; set; }
        public BankCard BankCard { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<CouponUser> CouponUsers { get; set; }
    }
}
