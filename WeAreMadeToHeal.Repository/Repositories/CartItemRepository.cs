using Dawn;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public class CartItemRepository : BaseRepository<CartItem>, ICartItemRepository
    {
        public CartItemRepository(WRMTHDbContext context) : base(context)
        {
            
        }

        #region [Custom Method Return Single]
        #endregion

        #region [Custom Method Return List]
        public async Task<List<CartItem>> GetByUserAsync(string id)
        {
            try
            {
                Guard.Argument(id, nameof(id));


                var dbResult = await _dbSet.AsNoTracking()
                                                .Where(x => x.UserId == id && x.IsActive).ToListAsync();
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
