using Dawn;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(WRMTHDbContext context) : base(context)
        {
           
        }


        #region [Custom Method Return Single]

        #endregion

        #region [Custom Method Return List]
        public async Task<List<Order>> GetByUserAsync(string userId)
        {
            try
            {
                Guard.Argument(userId, nameof(userId));


                var dbResult = await _dbSet.AsNoTracking()
                                                .Where(x => x.UserId == userId && x.IsActive).ToListAsync();
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
