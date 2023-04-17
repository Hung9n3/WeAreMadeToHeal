using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WeAreMadeToHeal.Extensions;

namespace WeAreMadeToHeal.Customer
{
    public class TagController : BaseCustomerController<Tag, ITagLogic>
    {
        public TagController(ILogger<BaseCustomerController<Tag, ITagLogic>> logger, LogicContext logicContext, ITagLogic logic) : base(logger, logicContext, logic)
        {
        }
    }
}
