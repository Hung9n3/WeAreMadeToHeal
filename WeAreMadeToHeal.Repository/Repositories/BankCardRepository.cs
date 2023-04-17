using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public class BankCardRepository : BaseRepository<BankCard>, IBankCardRepository
    {
        public BankCardRepository(WRMTHDbContext context) : base(context)
        {
        }
    }
}
