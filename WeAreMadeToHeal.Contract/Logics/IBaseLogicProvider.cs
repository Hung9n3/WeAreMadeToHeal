using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public interface IBaseLogicProvider<T> where T : BaseEntity
    {
        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task ActivateOrDeactiveAsync(string id, bool isActive);

        Task DeleteAsync(string id);

        Task<T> GetAsync(string id);

        Task<List<T>> GetAllAsync();

        Task<List<T>> GetActiveOrInActiveAsync(bool isActive);


        Task<List<T>> GetBatchAsync(List<string> entityIds);

        Task<List<T>> GetChangesAsync(DateTime date);
    }
}
