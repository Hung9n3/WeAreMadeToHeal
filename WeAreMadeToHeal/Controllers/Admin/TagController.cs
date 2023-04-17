using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WeAreMadeToHeal.Extensions;

namespace WeAreMadeToHeal.Admin
{
    public class TagController : BaseAdminController<Tag, ITagLogic>
    {
        public TagController(ILogger<BaseAdminController<Tag, ITagLogic>> logger, LogicContext logicContext, ITagLogic logic) : base(logger, logicContext, logic)
        {
        }
    }
}
