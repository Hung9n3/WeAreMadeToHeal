using Dawn;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public class BankCardRepository : BaseRepository<BankCard>, IBankCardRepository
    {
        public BankCardRepository(WRMTHDbContext context) : base(context)
        {
           
        }


        #region [Custom Method Return Single]
        public async Task<BankCard> GetByUserAsync(string userId)
        {
            try
            {
                Guard.Argument(userId, nameof(userId));


                var dbResult = await _dbSet.AsNoTracking()
                                                .Where(x => x.UserId == userId && x.IsActive).FirstOrDefaultAsync();
                return dbResult;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region [Custom Method Return List]
        #endregion
    }
}
