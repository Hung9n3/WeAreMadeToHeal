using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal
{
    public class TagController : BaseAdminController<Tag, ITagLogic>
    {
        public TagController(ILogger<BaseAdminController<Tag, ITagLogic>> logger, LogicContext logicContext, ITagLogic logic) : base(logger, logicContext, logic)
        {
        }
    }
}
