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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(WRMTHDbContext context) : base(context)
        {
        }

        #region [ Custom Method Void ]
        #endregion

        #region [ Custom Method Return Single ]
        public async Task<User> GetByUsername(string username)
        {
            try
            {
                Guard.Argument(username, nameof(username));


                var dbResult = await _dbSet.AsNoTracking()
                                                .FirstOrDefaultAsync(x => x.Username == username);
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


                var dbResult = await _dbSet.AsNoTracking()
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

        #region [ Custom Method Override ]
        public override async Task<User> GetAsync(string id)
        {
            try
            {
                Guard.Argument(id, nameof(id));


                var dbResult = await _dbSet.AsNoTracking().Where(x => x.Id == id && x.IsActive == true)
                                                          .FirstOrDefaultAsync();
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
