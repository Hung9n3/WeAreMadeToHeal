using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal
{
    public class CouponUserController : BaseAdminController<CouponUser, ICouponUserLogic>
    {
        public CouponUserController(ILogger<BaseAdminController<CouponUser, ICouponUserLogic>> logger, LogicContext logicContext, ICouponUserLogic logic) : base(logger, logicContext, logic)
        {
        }
    }
}
