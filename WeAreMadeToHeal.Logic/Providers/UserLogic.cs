using Dawn;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeAreMadeToHeal.Enums;

namespace WeAreMadeToHeal;

public class UserLogic : IUserLogic
{
    private readonly UserManager<User> _userManager;
    private readonly IUserRepository _repository;
    public UserLogic(UserManager<User> userManager, IUserRepository repository)
    {
        _userManager = userManager;
        _repository = repository;
    }

    public virtual Task AddAsync(User entity)
    {
        Guard.Argument(entity, "AddAsync");
        return _repository.AddAsync(entity);
    }

    public virtual Task UpdateAsync(User entity)
    {
        Guard.Argument(entity, "UpdateAsync");
        return _repository.UpdateAsync(entity);
    }

    public virtual Task ActivateOrDeactiveAsync(string id, bool isActive)
    {
        Guard.Argument(id, "ActivateAsync");
        return _repository.ActivateOrDeactiveAsync(id, isActive);
    }

    public virtual Task DeleteAsync(string id)
    {
        Guard.Argument(id, "DeleteAsync");
        return _repository.DeleteAsync(id);
    }

    public virtual Task DeleteBatchAsync(List<string> ids)
    {
        Guard.Argument(ids, "DeleteBatchAsync");
        List<Task> list = new List<Task>();
        foreach (string id in ids)
        {
            list.Add(_repository.DeleteAsync(id));
        }

        return Task.WhenAll(list);
    }

    public virtual Task<User> GetAsync(string id)
    {
        Guard.Argument(id, "GetAsync");
        return _repository.GetAsync(id);
    }

    public virtual Task<List<User>> GetAllAsync()
    { 
        return _repository.GetAllAsync();
    }

    public virtual Task<List<User>> GetActiveOrInActiveAsync(bool isActive)
    {      
        return _repository.GetActiveOrInActiveAsync(isActive);
    }

    public virtual Task<List<User>> GetActiveAsync()
    {   
        return _repository.GetActiveAsync();
    }

    public virtual Task<List<User>> GetInActiveAsync()
    {
        return _repository.GetInActiveAsync();
    }

    public virtual Task<List<User>> GetBatchAsync(List<string> entityIds)
    {
        return _repository.GetBatchAsync(entityIds);
    }

    public Task<User> GetByName(string name)
    {
        var result = _userManager.FindByNameAsync(name);
        return result;
    }

    public Task<List<User>> GetByRole(UserRoles role)
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByUsernameOrEmail(string payload)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetUnConfirmOrConfirmedEmail(bool isConfirm)
    {
        throw new NotImplementedException();
    }

    public Task<List<User>> GetUnConfirmOrConfirmedPhone(bool isConfirm)
    {
        throw new NotImplementedException();
    }

}
