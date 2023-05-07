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




        #region [Public Override Method]
        public override async Task<Order> GetAsync(string id)
        {
            try
            {
                Guard.Argument(id, nameof(id));


                var dbResult = await _dbSet.AsNoTracking()
                                                .Where(x => x.Id == id && x.IsActive).Include(x => x.OrderItems).FirstOrDefaultAsync();
                return dbResult;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override async Task<List<Order>> GetAllAsync()
        {
            try
            {
                var dbResult = await _dbSet.AsNoTracking()
                                                .Include(x => x.OrderItems).ToListAsync();
                return dbResult;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override async Task<List<Order>> GetBatchAsync(List<string> ids)
        {
            try
            {
                var dbResult = await _dbSet.AsNoTracking().
                                                Where(x => ids.Contains(x.Id) ).Include(x => x.OrderItems).ToListAsync();
                return dbResult;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public override async Task<List<Order>> GetActiveOrInActiveAsync(bool isActive)
        {
            try
            {

                var dbResult = await _dbSet.AsNoTracking()
                                                .Where(x => x.IsActive == isActive)
                                                .Include(x => x.OrderItems)
                                                .ToListAsync();
                return dbResult;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
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

        public async Task<List<Order>> GetByTimeInterval(DateTime startTime, DateTime endTime)
        {
            try
            {
                var dbResult = await _dbSet.AsNoTracking()
                                                .Where(x => x.CreatedAt >= startTime && x.CreatedAt <= endTime).ToListAsync();
                return dbResult;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateArriveStatus(string orderId)
        {
            try
            {
                Guard.Argument(orderId, nameof(orderId));



                var dbEntity = await _dbSet.FindAsync(orderId);
                if (dbEntity == null)
                {
                    throw new Exception($"entity with id {orderId} does not existed");
                }
                dbEntity.IsArrive = true;
                dbEntity.ArriveDate = DateTime.Now;
                dbEntity.UpdatedAt = DateTime.Now;
                _context.Update(dbEntity);
                await _context.SaveChangesAsync();
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

        public async Task UpdatePaidStatus(string orderId)
        {
            try
            {
                Guard.Argument(orderId, nameof(orderId));

                var dbEntity = await _dbSet.FindAsync(orderId);
                if (dbEntity == null)
                {
                    throw new Exception($"entity with id {orderId} does not existed");
                }
                dbEntity.IsPaid = true;
                dbEntity.UpdatedAt = DateTime.Now;
                _context.Update(dbEntity);
                await _context.SaveChangesAsync();
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
