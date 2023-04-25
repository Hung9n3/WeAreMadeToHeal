using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public interface IBaseRepository<User> where User : BaseEntity
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

        Task<List<User>> GetChangesAsync(DateTime date);
    }
}
