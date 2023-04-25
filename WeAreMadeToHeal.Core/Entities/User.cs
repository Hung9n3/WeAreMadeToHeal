using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using WeAreMadeToHeal.Enums;

namespace WeAreMadeToHeal
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; } = DateTime.MinValue;
        public UserRoles Role { get; set; }
        public string Address { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        public BankCard BankCard { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<CouponUser> CouponUsers { get; set; }
    }
}
