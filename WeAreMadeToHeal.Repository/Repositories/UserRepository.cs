using Dawn;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeAreMadeToHeal.Enums;

namespace WeAreMadeToHeal
{
    public class UserRepository : IUserRepository
    {
        private readonly WRMTHDbContext _context;
        private readonly DbSet<User> _dbSet;

        public UserRepository(WRMTHDbContext context)
        {
            _context = context;
            _dbSet = _context.Users;
        }

        #region [ Public Methods - Create / Update / Delete ]
        public virtual async Task AddAsync(User entity)
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

        public virtual async Task UpdateAsync(User entity)
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

        public virtual void OnUpdateEntityProperties(User sourceEntity, User databaseEntity)
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
        public virtual async Task<User> GetAsync(string id)
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
        public virtual async Task<List<User>> GetAllAsync()
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

        public virtual async Task<List<User>> GetActiveOrInActiveAsync(bool isActive)
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

        public virtual async Task<List<User>> GetActiveAsync()
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

        public virtual async Task<List<User>> GetInActiveAsync()
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

        public virtual async Task<List<User>> GetBatchAsync(List<string> entityIds)
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

        #region [ Custom Method Return Single ]
        public async Task<User> GetByUsername(string username)
        {
            try
            {
                Guard.Argument(username, nameof(username));


                var dbResult = await _dbSet.Include(x => x.BankCard).Include(x => x.CartItems).AsNoTracking()
                                                .FirstOrDefaultAsync(x => x.UserName == username);
                return dbResult;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<User> GetByEmail(string email)
        {
            try
            {
                Guard.Argument(email, nameof(email));


                var dbResult = await _dbSet.Include(x => x.BankCard).Include(x => x.CartItems).AsNoTracking()
                                                .FirstOrDefaultAsync(x => x.Email == email);
                return dbResult;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region [Custom Method Return List]

        public async Task<List<User>> GetUnConfirmOrConfirmedPhone(bool isConfirmed)
        {
            try
            {
                Guard.Argument(isConfirmed, nameof(isConfirmed));


                var dbResult = await _dbSet.AsNoTracking().Where(x => x.PhoneNumberConfirmed == isConfirmed)
                                                          .ToListAsync();
                return dbResult;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<User>> GetUnConfirmOrConfirmedEmail(bool isConfirmed)
        {
            try
            {
                Guard.Argument(isConfirmed, nameof(isConfirmed));


                var dbResult = await _dbSet.AsNoTracking().Where(x => x.EmailConfirmed == isConfirmed)
                                                          .ToListAsync();
                return dbResult;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<User>> GetByRole(UserRoles role)
        {
            try
            {
                Guard.Argument(role, nameof(role));


                var dbResult = await _dbSet.AsNoTracking().Where(x => x.Role == role)
                                                          .ToListAsync();
                return dbResult;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<User>> GetByName(string name)
        {
            try
            {
                Guard.Argument(name, nameof(name));


                var dbResult = await _dbSet.AsNoTracking().Where(x => x.Name == name)
                                                          .ToListAsync();
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
