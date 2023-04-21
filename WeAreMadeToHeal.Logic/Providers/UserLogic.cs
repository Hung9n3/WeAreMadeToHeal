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
    public UserLogic(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public Task<List<User>> GetByName(string name)
    {
        throw new NotImplementedException();
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

    #region [ Method List ]
    //public async Task<List<User>> GetAll()
    //{

    //}
    //#endregion

    //#region [ Method Return Single ]
    //public Task<User> GetByUsernameOrEmail(string payload)
    //{
    //    Guard.Argument(payload, "GetAsync");
    //}

    //#endregion

    //#region [Custom Method Return List]
    //public Task<List<User>> GetUnConfirmOrConfirmedEmail(bool isConfirm)
    //{
    //    Guard.Argument(isConfirm, nameof(isConfirm));
    //}

    //public Task<List<User>> GetUnConfirmOrConfirmedPhone(bool isConfirm)
    //{
    //    Guard.Argument(isConfirm, nameof(isConfirm));
    //}

    //public Task<List<User>> GetByName(string name)
    //{
    //    Guard.Argument(name, nameof(name));
    //}

    //public Task<List<User>> GetByRole(UserRoles role)
    //{
    //    Guard.Argument(role, nameof(role));
    //}
    #endregion

}
