using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal.Admin
{
    public class OrderItemController : BaseAdminController<OrderItem, IOrderItemLogic>
    {
        public OrderItemController(ILogger<BaseAdminController<OrderItem, IOrderItemLogic>> logger, LogicContext logicContext, IOrderItemLogic logic) : base(logger, logicContext, logic)
        {
        }
    }
}
