using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public interface IBankCardLogic : IBaseLogicProvider<BankCard>
    {
        Task<BankCard> GetByUserAsync(string userId);

    }
}
