﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public interface ICouponLogic : IBaseLogicProvider<Coupon>
    {
        Task<List<Coupon>> GetByUserAsync(string userId);

    }
}
