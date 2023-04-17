using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal.Admin
{
    public class CouponController : BaseAdminController<Coupon, ICouponLogic>
    {
        public CouponController(ILogger<BaseAdminController<Coupon, ICouponLogic>> logger, LogicContext logicContext, ICouponLogic logic) : base(logger, logicContext, logic)
        {
        }
    }
}
