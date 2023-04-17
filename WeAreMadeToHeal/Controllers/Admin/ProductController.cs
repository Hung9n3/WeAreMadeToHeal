using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal
{
    public class ProductController : BaseAdminController<Product, IProductLogic>
    {
        public ProductController(ILogger<BaseAdminController<Product, IProductLogic>> logger, LogicContext logicContext, IProductLogic logic) : base(logger, logicContext, logic)
        {
        }
    }
}
