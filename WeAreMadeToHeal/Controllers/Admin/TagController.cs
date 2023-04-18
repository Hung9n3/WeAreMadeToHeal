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

        [HttpGet("tag/{productId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> GetByProduct(string productId)
        {
            try
            {
                var result = await this._logic.GetByProduct(productId).ConfigureAwait(false);
                if (result == null)
                {
                    return base.NotFound(result);
                }
                result = result.Where(x => x.IsActive).ToList();
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
    }
}
