using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal.Customer
{
    public class ImageController : BaseCustomerController<Image, IImageLogic>
    {
        public ImageController(ILogger<BaseCustomerController<Image, IImageLogic>> logger, LogicContext logicContext, IImageLogic logic) : base(logger, logicContext, logic)
        {
        }
    }
}
