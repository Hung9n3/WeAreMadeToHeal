using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeAreMadeToHeal.Enums;

namespace WeAreMadeToHeal
{
    public interface IUserManager
    {
        Task AddAsync(User entity);

        Task ActivateOrDeactiveAsync(string id, bool isActive);

        Task DeleteAsync(string id);

        Task<User> GetAsync(string id);

        Task<List<User>> GetAllAsync();

        Task<List<User>> GetActiveOrInActiveAsync(bool isActive);

        Task<List<User>> GetActiveAsync();

        Task<List<User>> GetInActiveAsync();

        Task<List<User>> GetBatchAsync(List<string> entityIds);

        Task<User> GetByUsernameOrEmail(string payload);

        Task<User> GetByName(string name);
        Task<List<User>> GetByRole(UserRoles role);
        Task<List<User>> GetUnConfirmOrConfirmedPhone(bool isConfirm);
        Task<List<User>> GetUnConfirmOrConfirmedEmail(bool isConfirm);
    }
}
