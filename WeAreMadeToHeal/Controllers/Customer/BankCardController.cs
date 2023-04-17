using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal.Customer
{
    public class BankCardController : BaseCustomerController<BankCard, IBankCardLogic>
    {
        public BankCardController(ILogger<BaseCustomerController<BankCard, IBankCardLogic>> logger, LogicContext logicContext, IBankCardLogic logic) : base(logger, logicContext, logic)
        {
        }
    }
}
