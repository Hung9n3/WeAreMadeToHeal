﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public class CouponUser : BaseEntity
    {
        public string UserId { get; set; }
        public string CouponId { get; set; }
        public int Amount { get; set; }
    }
}
