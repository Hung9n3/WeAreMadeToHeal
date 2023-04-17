using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal;

public class OrderItemLogic : BaseLogic<OrderItem, IOrderItemRepository>, IOrderItemLogic
{
    public OrderItemLogic(IOrderItemRepository dataProvider) : base(dataProvider)
    {
        #region [Custom Method Return Single]
        #endregion

        #region [Custom Method Return List]
        #endregion
    }
}
