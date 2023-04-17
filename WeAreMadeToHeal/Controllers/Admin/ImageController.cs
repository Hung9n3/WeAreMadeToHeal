using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal
{
    public class ImageController : BaseAdminController<Image, IImageLogic>
    {
        public ImageController(ILogger<BaseAdminController<Image, IImageLogic>> logger, LogicContext logicContext, IImageLogic logic) : base(logger, logicContext, logic)
        {
        }
    }
}
