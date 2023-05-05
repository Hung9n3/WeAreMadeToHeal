using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal;

public interface IAuthenticationLogic
{
    Task<string> GetValidEmailToken(User user);
    Task<string> Login(string username, string password);
    Task<User> Register(User user, string password);
}
