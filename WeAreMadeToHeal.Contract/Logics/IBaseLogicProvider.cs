using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public interface IBaseLogicProvider<TEntity> where TEntity : BaseEntity
    {
        Task AddAsync(TEntity entity);

        Task SaveRangeAsync(List<TEntity> entity);

        Task UpdateAsync(TEntity entity);

        Task ActivateOrDeactiveAsync(string id, bool isActive);

        Task DeleteAsync(string id);

        Task<TEntity> GetAsync(string id);

        Task<List<TEntity>> GetAllAsync();

        Task<List<TEntity>> GetActiveOrInActiveAsync(bool isActive);

        Task<List<TEntity>> GetActiveAsync();

        Task<List<TEntity>> GetInActiveAsync();

        Task<List<TEntity>> GetBatchAsync(List<string> entityIds);

        Task<List<TEntity>> GetChangesAsync(DateTime date);
    }
}
