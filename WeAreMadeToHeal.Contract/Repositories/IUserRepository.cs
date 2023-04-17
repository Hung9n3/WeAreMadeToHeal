using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeAreMadeToHeal.Enums;

namespace WeAreMadeToHeal
{
    public interface IUserRepository : IBaseRepository<User>
    {

        Task<User> GetByEmail(string email);
        Task<User> GetByUsername(string username);

        Task<List<User>> GetByName(string name);
        Task<List<User>> GetByRole(UserRoles role);
        Task<List<User>> GetUnConfirmOrConfirmedPhone(bool isConfirm);
        Task<List<User>> GetUnConfirmOrConfirmedEmail(bool isConfirm);
    }
}
