using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal.Customer
{
    public class CouponController : BaseCustomerController<Coupon, ICouponLogic>
    {
        public CouponController(ILogger<BaseCustomerController<Coupon, ICouponLogic>> logger, LogicContext logicContext, ICouponLogic logic) : base(logger, logicContext, logic)
        {
        }
    }
}
