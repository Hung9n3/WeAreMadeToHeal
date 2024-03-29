﻿using Dawn;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Reflection;

namespace WeAreMadeToHeal
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        #region [ Fields ]
        protected readonly WRMTHDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        #endregion

        #region [ CTor ]
        public BaseRepository(WRMTHDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        #endregion

        #region [ Public Methods - Create / Update / Delete ]
        public virtual async Task AddAsync(TEntity entity)
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

        public async Task SaveRangeAsync(List<TEntity> entity)
        {
            try
            {
                Guard.Argument(entity, nameof(entity));

                foreach(var item in entity)
                {
                    if (await _dbSet.AnyAsync(x => x.Id == item.Id))
                    {
                        _dbSet.Update(item);
                    }
                    else await _dbSet.AddAsync(item);

                }
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

        public virtual async Task UpdateAsync(TEntity entity)
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

        public virtual void OnUpdateEntityProperties(TEntity sourceEntity, TEntity databaseEntity)
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
        public virtual async Task<TEntity> GetAsync(string id)
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
        public virtual async Task<List<TEntity>> GetAllAsync()
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

        public virtual async Task<List<TEntity>> GetActiveOrInActiveAsync(bool isActive)
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

        public virtual async Task<List<TEntity>> GetActiveAsync()
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

        public virtual async Task<List<TEntity>> GetInActiveAsync()
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

        public virtual async Task<List<TEntity>> GetBatchAsync(List<string> entityIds)
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

        public virtual async Task<List<TEntity>> GetByNameAsync(string name)
        {
            try
            {
                var dbResult = new List<TEntity>();
                Guard.Argument(name, nameof(name));
                var properties = typeof(TEntity).GetProperties();
                if (properties.Any(x => x.Name == "Name"))
                {
                    foreach (var property in properties)
                    {
                        if (property.Name == "Name")
                        {
                            var param = Expression.Parameter(typeof(TEntity));
                            MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                            var condition =
                            Expression.Lambda<Func<TEntity, bool>>(
                                    Expression.Call(
                                        Expression.Property(param, "Name"),
                                        method,
                                        Expression.Constant(name, typeof(string))
                                    ),
                                    param
                                );
                            dbResult = await _dbSet.AsNoTracking()
                                               .Where(condition)
                                               .ToListAsync();
                            break;
                        }
                    }
                    return dbResult;
                }
                else return new List<TEntity>();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual async Task<List<TEntity>> GetChangesAsync(DateTime date)
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
