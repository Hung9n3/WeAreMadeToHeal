﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public class CouponUserRepository : BaseRepository<CouponUser>, ICouponUserRepository
    {
        public CouponUserRepository(WRMTHDbContext context) : base(context)
        {
            #region [Custom Method Return Single]
            #endregion

            #region [Custom Method Return List]
            #endregion
        }
    }
}
