using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public interface ICouponRepository : IBaseRepository<Coupon>
    {
        Task<List<Coupon>> GetByUserAsync(string userId);
    }
}
