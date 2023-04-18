using Dawn;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(WRMTHDbContext context) : base(context)
        {
            
        }
        #region [Custom Method Return Single]
        #endregion

        #region [Custom Method Return List]
        public async Task<List<Product>> GetByCategory(string cateId)
        {
            try
            {
                Guard.Argument(cateId, nameof(cateId));


                var dbResult = await _dbSet.AsNoTracking()
                                                .Where(x => x.CategoryId == cateId).ToListAsync();
                return dbResult;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Product>> GetByTag(string tagId)
        {
            try
            {
                Guard.Argument(tagId, nameof(tagId));

                var productIds = await _context.TagsProduct.Where(x => x.TagId == tagId).Select(x => x.ProductId).ToListAsync();
                if(productIds.Count == 0)
                {
                    return null;
                }
                var dbResult = await this.GetBatchAsync(productIds);
                return dbResult;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Product>> GetBySize(string size)
        {
            try
            {
                Guard.Argument(size, nameof(size));


                var dbResult = await _dbSet.AsNoTracking()
                                                .Where(x => x.Size == size).ToListAsync();
                return dbResult;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Product>> GetByColor(string color)
        {
            try
            {
                Guard.Argument(color, nameof(color));


                var dbResult = await _dbSet.AsNoTracking()
                                                .Where(x => x.Color == color).ToListAsync();
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
