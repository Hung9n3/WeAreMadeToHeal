﻿using Dawn;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public class BaseLogic<User, TDb> : IBaseLogicProvider<User> where User : BaseEntity where TDb : IBaseRepository<User>
    {
        protected readonly TDb _dataProvider;

        public BaseLogic(TDb dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public virtual Task AddAsync(User entity)
        {
            Guard.Argument(entity, "AddAsync");
            TDb dataProvider = _dataProvider;
            return dataProvider.AddAsync(entity);
        }

        public virtual Task UpdateAsync(User entity)
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

        public virtual Task<User> GetAsync(string id)
        {
            Guard.Argument(id, "GetAsync");
            TDb dataProvider = _dataProvider;
            return dataProvider.GetAsync(id);
        }

        public virtual Task<List<User>> GetAllAsync()
        {
            TDb dataProvider = _dataProvider;
            return dataProvider.GetAllAsync();
        }

        public virtual Task<List<User>> GetActiveOrInActiveAsync(bool isActive)
        {
            TDb dataProvider = _dataProvider;
            return dataProvider.GetActiveOrInActiveAsync(isActive);
        }

        public virtual Task<List<User>> GetActiveAsync()
        {
            TDb dataProvider = _dataProvider;
            return dataProvider.GetActiveAsync();
        }

        public virtual Task<List<User>> GetInActiveAsync()
        {
            TDb dataProvider = _dataProvider;
            return dataProvider.GetInActiveAsync();
        }

        public virtual Task<List<User>> GetBatchAsync(List<string> entityIds)
        {
            TDb dataProvider = _dataProvider;
            return dataProvider.GetBatchAsync(entityIds);
        }

        public virtual Task<List<User>> GetChangesAsync(DateTime date)
        {
            Guard.Argument(date, "date");
            TDb dataProvider = _dataProvider;
            return dataProvider.GetChangesAsync(date);
        }
    }
}
