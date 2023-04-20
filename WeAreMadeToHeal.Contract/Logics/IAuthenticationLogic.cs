using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal;

public interface IAuthenticationLogic
{
    Task<string> Login(string username, string password);
}
