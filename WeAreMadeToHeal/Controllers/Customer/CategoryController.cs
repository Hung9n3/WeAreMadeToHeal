using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal.Customer
{
    public class CategoryController : BaseCustomerController<Category, ICategoryLogic>
    {
        public CategoryController(ILogger<BaseCustomerController<Category, ICategoryLogic>> logger, LogicContext logicContext, ICategoryLogic logic) : base(logger, logicContext, logic)
        {
        }
    }
}
