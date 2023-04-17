using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal.Customer
{
    public class UserController : BaseCustomerController<User, IUserLogic>
    {
        public UserController(ILogger<BaseCustomerController<User, IUserLogic>> logger, LogicContext logicContext, IUserLogic logic) : base(logger, logicContext, logic)
        {
        }
    }
}
