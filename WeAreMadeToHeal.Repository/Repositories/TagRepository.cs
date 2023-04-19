using Dawn;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(WRMTHDbContext context) : base(context)
        {
            
        }


        #region [Custom Method Return Single]
        #endregion

        #region [Custom Method Return List]
        public async Task<List<Tag>> GetByProduct(string productId)
        {
            try
            {
                Guard.Argument(productId, nameof(productId));

                var tagIds = await _context.TagProducts.Where(x => x.ProductId == productId).Select(x => x.TagId).ToListAsync();
                if (tagIds.Count == 0)
                {
                    return null;
                }
                var dbResult = await this.GetBatchAsync(tagIds);
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
