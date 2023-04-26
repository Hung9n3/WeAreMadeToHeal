using Dawn;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public class BaseLogic<TEntity, TDb> : IBaseLogicProvider<TEntity> where TEntity : BaseEntity where TDb : IBaseRepository<TEntity>
    {
        protected readonly TDb _dataProvider;

        public BaseLogic(TDb dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public virtual Task AddAsync(TEntity entity)
        {
            Guard.Argument(entity, "AddAsync");
            TDb dataProvider = _dataProvider;
            return dataProvider.AddAsync(entity);
        }

        public Task SaveRangeAsync(List<TEntity> entity)
        {
            Guard.Argument(entity, "AddAsync");
            TDb dataProvider = _dataProvider;
            return dataProvider.SaveRangeAsync(entity);
        }

        public virtual Task UpdateAsync(TEntity entity)
        {
            Guard.Argument(entity, "UpdateAsync");
            TDb dataProvider = _dataProvider;
            return dataProvider.UpdateAsync(entity);
        }

        public virtual Task ActivateOrDeactiveAsync(string id, bool isActive)
        {
            Guard.Argument(id, "ActivateAsync");
            TDb dataProvider = _dataProvider;
            return dataProvider.ActivateOrDeactiveAsync(id, isActive);
        }

        public virtual Task DeleteAsync(string id)
        {
            Guard.Argument(id, "DeleteAsync");
            TDb dataProvider = _dataProvider;
            return dataProvider.DeleteAsync(id);
        }

        public virtual Task DeleteBatchAsync(List<string> ids)
        {
            Guard.Argument(ids, "DeleteBatchAsync");
            List<Task> list = new List<Task>();
            foreach (string id in ids)
            {
                TDb dataProvider = _dataProvider;
                list.Add(dataProvider.DeleteAsync(id));
            }

            return Task.WhenAll(list);
        }

        public virtual Task<TEntity> GetAsync(string id)
        {
            Guard.Argument(id, "GetAsync");
            TDb dataProvider = _dataProvider;
            return dataProvider.GetAsync(id);
        }

        public virtual Task<List<TEntity>> GetAllAsync()
        {
            TDb dataProvider = _dataProvider;
            return dataProvider.GetAllAsync();
        }

        public virtual Task<List<TEntity>> GetActiveOrInActiveAsync(bool isActive)
        {
            TDb dataProvider = _dataProvider;
            return dataProvider.GetActiveOrInActiveAsync(isActive);
        }

        public virtual Task<List<TEntity>> GetActiveAsync()
        {
            TDb dataProvider = _dataProvider;
            return dataProvider.GetActiveAsync();
        }

        public virtual Task<List<TEntity>> GetInActiveAsync()
        {
            TDb dataProvider = _dataProvider;
            return dataProvider.GetInActiveAsync();
        }

        public virtual Task<List<TEntity>> GetBatchAsync(List<string> entityIds)
        {
            TDb dataProvider = _dataProvider;
            return dataProvider.GetBatchAsync(entityIds);
        }

        public virtual Task<List<TEntity>> GetChangesAsync(DateTime date)
        {
            Guard.Argument(date, "date");
            TDb dataProvider = _dataProvider;
            return dataProvider.GetChangesAsync(date);
        }

        public virtual Task<List<TEntity>> GetByNameAsync(string name)
        {
            Guard.Argument(name, nameof(name));
            TDb dataProvider = _dataProvider;
            return dataProvider.GetByNameAsync(name);
        }
    }
}
