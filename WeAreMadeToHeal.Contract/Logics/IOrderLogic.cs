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
        Task<List<Order>> GetByTimeInterval(DateTime startTime, DateTime endTime);
        Task UpdateArriveStatus(string orderId);
        Task UpdatePaidStatus(string orderId);
    }
}
