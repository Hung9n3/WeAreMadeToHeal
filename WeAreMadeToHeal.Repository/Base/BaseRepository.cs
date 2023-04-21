using Dawn;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        #region [ Fields ]
        protected readonly WRMTHDbContext _context;
        protected readonly DbSet<T> _dbSet;
        #endregion

        #region [ CTor ]
        public BaseRepository(WRMTHDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        #endregion

        #region [ Public Methods - Create / Update / Delete ]
        public virtual async Task AddAsync(T entity)
        {
            try
            {
                Guard.Argument(entity, nameof(entity));



                var dbEntity = await _dbSet.FindAsync(entity.Id);
                if (dbEntity != null)
                {
                    throw new Exception($"entity with id {entity.Id} existed");
                }

                _context.Add(entity);
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

        public virtual async Task UpdateAsync(T entity)
        {
            try
            {
                Guard.Argument(entity, nameof(entity));



                var dbEntity = await _dbSet.FindAsync(entity.Id);
                if (dbEntity == null)
                {
                    throw new Exception($"entity with id {entity.Id} not found");
                }

                OnUpdateEntityProperties(entity, dbEntity);
                entity.UpdatedAt = DateTime.UtcNow;

                _context.Update(entity);
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

        public virtual void OnUpdateEntityProperties(T sourceEntity, T databaseEntity)
        {

            Guard.Argument(sourceEntity, nameof(sourceEntity));
            Guard.Argument(databaseEntity, nameof(databaseEntity));

            foreach (var property in databaseEntity.GetType().GetProperties())
            {
                var value = property.GetValue(sourceEntity);
                if (property.CanWrite)
                {
                    property.SetValue(databaseEntity, value);
                }
            }
        }

        public virtual async Task ActivateOrDeactiveAsync(string id, bool isActive)
        {
            try
            {
                Guard.Argument(id, nameof(id));


                var dbEntity = await _dbSet.FindAsync(id);
                if (dbEntity == null)
                {
                    throw new Exception($"entity with id {id} not found");
                }
                dbEntity.IsActive = isActive;
                _context.Update(dbEntity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task DeleteAsync(string id)
        {
            try
            {
                Guard.Argument(id, nameof(id));


                var dbEntity = await _dbSet.FindAsync(id);
                if (dbEntity == null)
                {
                    throw new Exception($"entity with id {id} not found");
                }
                _context.Remove(dbEntity);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region [ Public Methods - Get Single ]
        public virtual async Task<T> GetAsync(string id)
        {
            try
            {
                Guard.Argument(id, nameof(id));


                var dbResult = await _dbSet.AsNoTracking()
                                                .FirstOrDefaultAsync(x => x.Id == id);
                return dbResult;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region [ Public Methods - Get List ]
        public virtual async Task<List<T>> GetAllAsync()
        {
            try
            {

                var dbResult = await _dbSet.AsNoTracking()
                                            .ToListAsync();
                return dbResult;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task<List<T>> GetActiveOrInActiveAsync(bool isActive)
        {
            try
            {

                var dbResult = await _dbSet.AsNoTracking()
                                                .Where(x => x.IsActive == isActive)
                                                .ToListAsync();
                return dbResult;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task<List<T>> GetActiveAsync()
        {
            try
            {

                var dbrResult = await _dbSet.AsNoTracking()
                                                .Where(x => x.IsActive == true)
                                                .ToListAsync();
                return dbrResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task<List<T>> GetInActiveAsync()
        {
            try
            {

                var dbrResult = await _dbSet.AsNoTracking()
                                                .Where(x => x.IsActive == false)
                                                .ToListAsync();
                return dbrResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task<List<T>> GetBatchAsync(List<string> entityIds)
        {
            try
            {
                foreach (var entityId in entityIds)
                {
                    Guard.Argument(entityId, nameof(entityIds));
                }


                var dbResult = await _dbSet.AsNoTracking()
                                                .Where(x => entityIds.Contains(x.Id))
                                                .ToListAsync();
                return dbResult;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task<List<T>> GetChangesAsync(DateTime date)
        {
            try
            {
                Guard.Argument(date, nameof(date));


                var dbResult = await _dbSet.AsNoTracking()
                                                .Where(x => x.UpdatedAt < date)
                                                .ToListAsync();
                return dbResult;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task<List<string>> GetAllIds()
        {
            try
            {

                var dbResult = await _dbSet.AsNoTracking().Select(x => x.Id)
                                            .ToListAsync();
                return dbResult;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region [ Public Methods - Checks ]
        public async Task<bool> AnyAsync()
        {
            try
            {

                var dbResult = await _dbSet.AsNoTracking()
                                            .AnyAsync();
                return dbResult;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region [ Private Methods ]
        #endregion
    }
}
