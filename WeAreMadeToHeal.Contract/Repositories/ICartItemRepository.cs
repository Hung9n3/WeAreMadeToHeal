﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public interface ICartItemRepository : IBaseRepository<CartItem>
    {
        Task<List<CartItem>> GetByUserAsync(string userId);
    }
}
