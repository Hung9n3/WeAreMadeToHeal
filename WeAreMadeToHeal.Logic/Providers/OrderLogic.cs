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
    public Task<List<Order>> GetByTimeInterval(DateTime startTime, DateTime endTime)
    {
        var result = _dataProvider.GetByTimeInterval(startTime,endTime);
        return result;
    }
    public Task<List<Order>> GetByUserAsync(string userId)
    {
        Guard.Argument(userId, nameof(userId));
        var result = _dataProvider.GetByUserAsync(userId);
        return result;
    }

    public Task UpdateArriveStatus(string orderId)
    {
        Guard.Argument(orderId, "UpdateArriveStatus");
        var result = _dataProvider.UpdateArriveStatus(orderId);
        return result;
    }

    public Task UpdatePaidStatus(string orderId)
    {
        Guard.Argument(orderId, "UpdatePaidStatus");
        var result = _dataProvider.UpdatePaidStatus(orderId);
        return result;
    }
    #endregion

}
