using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal.Admin
{
    public class CartItemController : BaseAdminController<CartItem, ICartItemLogic>
    {
        public CartItemController(ILogger<BaseAdminController<CartItem, ICartItemLogic>> logger, ExcelHandlerService excelHandlerService, LogicContext logicContext, ICartItemLogic logic) : base(logger, excelHandlerService, logicContext, logic)
        {
        }
    }
}
