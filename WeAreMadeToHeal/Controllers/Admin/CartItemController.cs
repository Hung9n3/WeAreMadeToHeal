using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal
{
    public class CartItemController : BaseAdminController<CartItem, ICartItemLogic>
    {
        public CartItemController(ILogger<BaseAdminController<CartItem, ICartItemLogic>> logger, LogicContext logicContext, ICartItemLogic logic) : base(logger, logicContext, logic)
        {
        }
    }
}
