using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal
{
    public class BankCardController : BaseAdminController<BankCard, IBankCardLogic>
    {
        public BankCardController(ILogger<BaseAdminController<BankCard, IBankCardLogic>> logger, LogicContext logicContext, IBankCardLogic logic) : base(logger, logicContext, logic)
        {
        }
    }
}
