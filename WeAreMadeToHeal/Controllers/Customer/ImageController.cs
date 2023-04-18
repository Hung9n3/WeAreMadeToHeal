using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal.Customer
{
    public class ImageController : BaseCustomerController<Image, IImageLogic>
    {
        public ImageController(ILogger<BaseCustomerController<Image, IImageLogic>> logger, LogicContext logicContext, IImageLogic logic) : base(logger, logicContext, logic)
        {
        }

        #region [ Public Methods - List ]
        
        [HttpGet("product/{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> GetByProductAsync(string productId)
        {
            try
            {
                var result = await this._logic.GetByProductAsync(productId).ConfigureAwait(false);
                if (result == null)
                {
                    return base.NotFound(result);
                }
                return base.Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                this._logger.LogError(ex, "Error in {0}", "");
                return base.BadRequest();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Error in {0}", "");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        #endregion
    }
}
