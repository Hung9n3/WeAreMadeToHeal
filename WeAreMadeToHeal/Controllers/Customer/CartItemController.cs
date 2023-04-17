using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal.Customer
{
    public class CartItemController : BaseCustomerController<CartItem, ICartItemLogic>
    {
        public CartItemController(ILogger<BaseCustomerController<CartItem, ICartItemLogic>> logger, LogicContext logicContext, ICartItemLogic logic) : base(logger, logicContext, logic)
        {
        }
    }
}
