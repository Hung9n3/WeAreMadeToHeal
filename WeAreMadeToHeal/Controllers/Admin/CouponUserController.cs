using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal.Admin
{
    public class CouponUserController : BaseAdminController<CouponUser, ICouponUserLogic>
    {
        public CouponUserController(ILogger<BaseAdminController<CouponUser, ICouponUserLogic>> logger, ExcelHandlerService excelHandlerService, LogicContext logicContext, ICouponUserLogic logic) : base(logger, excelHandlerService, logicContext, logic)
        {
        }
    }
}
