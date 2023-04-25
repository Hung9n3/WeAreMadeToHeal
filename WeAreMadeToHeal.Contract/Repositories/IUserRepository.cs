using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeAreMadeToHeal.Enums;

namespace WeAreMadeToHeal
{
    public interface IUserRepository
    {
        Task AddAsync(User entity);

        Task UpdateAsync(User entity);

        Task ActivateOrDeactiveAsync(string id, bool isActive);

        Task DeleteAsync(string id);

        Task<User> GetAsync(string id);

        Task<List<User>> GetAllAsync();

        Task<List<User>> GetActiveOrInActiveAsync(bool isActive);

        Task<List<User>> GetActiveAsync();

        Task<List<User>> GetInActiveAsync();

        Task<List<User>> GetBatchAsync(List<string> entityIds);

        Task<User> GetByEmail(string email);
        Task<User> GetByUsername(string username);

        Task<List<User>> GetByName(string name);
        Task<List<User>> GetByRole(UserRoles role);
        Task<List<User>> GetUnConfirmOrConfirmedPhone(bool isConfirm);
        Task<List<User>> GetUnConfirmOrConfirmedEmail(bool isConfirm);
    }
}
