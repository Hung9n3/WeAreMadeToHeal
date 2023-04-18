using Dawn;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public class CouponRepository : BaseRepository<Coupon>, ICouponRepository
    {
        public CouponRepository(WRMTHDbContext context) : base(context)
        {
            
        }


        #region [Custom Method Return Single]
        #endregion

        #region [Custom Method Return List]
        public async Task<List<Coupon>> GetByUserAsync(string userId)
        {
            try
            {               
                Guard.Argument(userId, nameof(userId));
                
                var couponIds = await _context.CouponUsers.Where(x => x.UserId == userId).Select(x => x.CouponId).ToListAsync();

                var dbResult = await this.GetBatchAsync(couponIds);
                return dbResult;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
