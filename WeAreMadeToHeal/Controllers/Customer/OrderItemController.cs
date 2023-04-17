using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal.Customer
{
    public class OrderItemController : BaseCustomerController<OrderItem, IOrderItemLogic>
    {
        public OrderItemController(ILogger<BaseCustomerController<OrderItem, IOrderItemLogic>> logger, LogicContext logicContext, IOrderItemLogic logic) : base(logger, logicContext, logic)
        {
        }
    }
}
