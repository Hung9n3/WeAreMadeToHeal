using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal.Customer
{
    public class CouponUserController : BaseCustomerController<CouponUser, ICouponUserLogic>
    {
        public CouponUserController(ILogger<BaseCustomerController<CouponUser, ICouponUserLogic>> logger, LogicContext logicContext, ICouponUserLogic logic) : base(logger, logicContext, logic)
        {
        }
    }
}
