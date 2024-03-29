﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public interface ICartItemLogic : IBaseLogicProvider<CartItem>
    {
        Task<List<CartItem>> GetByUserAsync(string userId);
    }
}
