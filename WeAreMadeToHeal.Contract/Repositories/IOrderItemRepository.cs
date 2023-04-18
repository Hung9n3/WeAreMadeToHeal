using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public interface IOrderItemRepository : IBaseRepository<OrderItem>
    {
        Task<List<OrderItem>> GetByOrderAsync(string orderId);
    }
}
