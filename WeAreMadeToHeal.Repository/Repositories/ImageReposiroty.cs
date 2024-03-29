﻿using Dawn;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public class ImageRepository : BaseRepository<Image>, IImageRepository
    {
        public ImageRepository(WRMTHDbContext context) : base(context)
        {
            
        }


        #region [Custom Method Return Single]
        #endregion

        #region [Custom Method Return List]
        public async Task<List<Image>> GetByProductAsync(string productId)
        {
            try
            {
                Guard.Argument(productId, nameof(productId));


                var dbResult = await _dbSet.AsNoTracking()
                                                .Where(x => x.ProductId == productId).ToListAsync();
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
