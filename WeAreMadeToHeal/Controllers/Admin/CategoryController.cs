using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal.Admin
{
    public class CategoryController : BaseAdminController<Category, ICategoryLogic>
    {
        public CategoryController(ILogger<BaseAdminController<Category, ICategoryLogic>> logger, LogicContext logicContext, ICategoryLogic logic) : base(logger, logicContext, logic)
        {
        }
    }
}
