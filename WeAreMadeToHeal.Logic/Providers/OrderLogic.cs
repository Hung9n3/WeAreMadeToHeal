using Dawn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal;

public class OrderLogic : BaseLogic<Order, IOrderRepository>, IOrderLogic
{
    public OrderLogic(IOrderRepository dataProvider) : base(dataProvider)
    {
        
    }
    #region [Custom Method Return Single]

    #endregion

    #region [Custom Method Return List]
    public Task<List<Order>> GetByUserAsync(string userId)
    {
        Guard.Argument(userId, nameof(userId));
        var result = _dataProvider.GetByUserAsync(userId);
        return result;
    }
    #endregion

}
