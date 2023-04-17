using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeAreMadeToHeal.Enums;

namespace WeAreMadeToHeal
{
    public interface IUserLogic : IBaseLogicProvider<User>
    {
        Task<User> GetByUsernameOrEmail(string payload);

        Task<List<User>> GetByName(string name);
        Task<List<User>> GetByRole(UserRoles role);
        Task<List<User>> GetUnConfirmOrConfirmedPhone(bool isConfirm);
        Task<List<User>> GetUnConfirmOrConfirmedEmail(bool isConfirm);
    }
}
