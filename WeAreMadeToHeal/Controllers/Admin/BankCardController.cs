using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal.Admin
{
    public class BankCardController : BaseAdminController<BankCard, IBankCardLogic>
    {
        public BankCardController(ILogger<BaseAdminController<BankCard, IBankCardLogic>> logger, ExcelHandlerService excelHandlerService, LogicContext logicContext, IBankCardLogic logic) : base(logger, excelHandlerService, logicContext, logic)
        {
        }
    }
}
