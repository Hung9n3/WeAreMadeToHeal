using Dawn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeAreMadeToHeal.Enums;

namespace WeAreMadeToHeal;

public class UserLogic : BaseLogic<User, IUserRepository>, IUserLogic
{
    public UserLogic(IUserRepository dataProvider) : base(dataProvider)
    {
    }

    #region [ Custom Method Void ]
    #endregion

    #region [ Custom Method Return Single ]
    public Task<User> GetByUsernameOrEmail(string payload)
    {
        Guard.Argument(payload, "GetAsync");
        if(payload.Contains("@"))
        {
            var result = _dataProvider.GetByEmail(payload);
            return result;
        }
        else
        {
            var result = _dataProvider.GetByUsername(payload);
            return result;
        }
    }

    #endregion

    #region [Custom Method Return List]
    public Task<List<User>> GetUnConfirmOrConfirmedEmail(bool isConfirm)
    {
        Guard.Argument(isConfirm, nameof(isConfirm));
        var result = _dataProvider.GetUnConfirmOrConfirmedEmail(isConfirm);
        return result;
    }

    public Task<List<User>> GetUnConfirmOrConfirmedPhone(bool isConfirm)
    {
        Guard.Argument(isConfirm, nameof(isConfirm));
        var result = _dataProvider.GetUnConfirmOrConfirmedPhone(isConfirm);
        return result;
    }

    public Task<List<User>> GetByName(string name)
    {
        Guard.Argument(name, nameof(name));
        var result = _dataProvider.GetByName(name);
        return result;
    }

    public Task<List<User>> GetByRole(UserRoles role)
    {
        Guard.Argument(role, nameof(role));
        var result = _dataProvider.GetByRole(role);
        return result;
    }
    #endregion

}
