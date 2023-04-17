using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal;

public class UserLogic : BaseLogic<User, IUserRepository>, IUserLogic
{
    public UserLogic(IUserRepository dataProvider) : base(dataProvider)
    {
    }
}
