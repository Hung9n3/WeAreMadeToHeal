using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public interface IOrderLogic : IBaseLogicProvider<Order>
    {
        Task<List<Order>> GetByUserAsync(string userId);
    }
}
