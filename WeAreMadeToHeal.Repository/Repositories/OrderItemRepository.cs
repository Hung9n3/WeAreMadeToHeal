using Dawn;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(WRMTHDbContext context) : base(context)
        {

        }

        #region [Custom Method Return Single]
        #endregion

        #region [Custom Method Return List]
        public async Task<List<OrderItem>> GetByOrderAsync(string orderId)
        {
            try
            {
                Guard.Argument(orderId, nameof(orderId));


                var dbResult = await _dbSet.AsNoTracking()
                                                .Where(x => x.OrderId == orderId).ToListAsync();
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
