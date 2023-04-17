using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(WRMTHDbContext context) : base(context)
        {
        }
    }
}
