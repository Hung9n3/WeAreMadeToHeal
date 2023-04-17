using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal.Customer
{
    public class ProductController : BaseCustomerController<Product, IProductLogic>
    {
        public ProductController(ILogger<BaseCustomerController<Product, IProductLogic>> logger, LogicContext logicContext, IProductLogic logic) : base(logger, logicContext, logic)
        {
        }
    }
}
