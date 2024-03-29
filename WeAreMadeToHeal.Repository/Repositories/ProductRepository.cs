﻿using Dawn;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        #region [Public Method Override]
        public override async Task<List<Product>> GetAllAsync()
        {
            try
            { 
                var dbResult = await _dbSet.Include(x => x.Images).AsNoTracking()
                                                .ToListAsync();
                return dbResult;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override async Task<Product> GetAsync(string id)
        {
            try
            {
                Guard.Argument(id, nameof(id));

                var dbResult = await _dbSet.Include(x => x.Images).AsNoTracking()
                                                .FirstOrDefaultAsync(x => x.Id == id);
                return dbResult;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

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

                var productIds = await _context.TagProducts.Where(x => x.TagId == tagId).Select(x => x.ProductId).ToListAsync();
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

        public async Task UpdateAmountByOrder(Order order)
        {
            try
            {
                Guard.Argument(order, nameof(order));
                Guard.Argument(order.OrderItems, nameof(order.OrderItems));


                foreach(var item in order.OrderItems)
                {
                    var product = await base.GetAsync(item.ProductId);
                    if (product == null) 
                    {
                        throw new Exception($"product with id {item.ProductId} does not existed");
                    }
                    product.Amount -= item.Amount;
                    _dbSet.Update(product);
                    await _context.SaveChangesAsync();
                }

            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException("An Exception occured. See inner stack trace for details.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

    }
}
