﻿using Dawn;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WeAreMadeToHeal.Enums;

namespace WeAreMadeToHeal;

public class UserManager : UserManager<User>, IUserManager
{
    private readonly IUserRepository _repository;
    public UserManager(IUserStore<User> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<User> passwordHasher,
            IEnumerable<IUserValidator<User>> userValidators,
            IEnumerable<IPasswordValidator<User>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            ILogger<UserManager<User>> logger,
            IUserRepository userRepository
        ) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
        _repository = userRepository;
    }

    public virtual Task AddAsync(User entity)
    {
        Guard.Argument(entity, "AddAsync");
        return _repository.AddAsync(entity);
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

    public Task<List<User>> GetByName(string name)
    {
        Guard.Argument(name, nameof(name));
        var result = _repository.GetByName(name);
        return result;
    }

    public Task<List<User>> GetByRole(UserRoles role)
    {
        var result = _repository.GetByRole(role);
        return result;
    }

    public Task<User> GetByUsernameOrEmail(string payload)
    {
        Guard.Argument(payload, nameof(payload));
        Regex regex = new(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match= regex.Match(payload);
        if(match.Success)
        {
            return _repository.GetByEmail(payload);
        }
        else return _repository.GetByUsername(payload);
    }

    public Task<List<User>> GetUnConfirmOrConfirmedEmail(bool isConfirm)
    {
        return _repository.GetUnConfirmOrConfirmedEmail(isConfirm);
    }

    public Task<List<User>> GetUnConfirmOrConfirmedPhone(bool isConfirm)
    {
        return _repository.GetUnConfirmOrConfirmedPhone(isConfirm);

    }

}
