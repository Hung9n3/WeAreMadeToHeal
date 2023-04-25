using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal.Admin
{
    public class CouponController : BaseAdminController<Coupon, ICouponLogic>
    {
        public CouponController(ILogger<BaseAdminController<Coupon, ICouponLogic>> logger, ExcelHandlerService excelHandlerService, LogicContext logicContext, ICouponLogic logic) : base(logger, excelHandlerService, logicContext, logic)
        {
        }

        #region [ Public Methods - List ]
        [HttpGet("user/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> GetByUserAsync(string userId)
        {
            try
            {
                var result = await this._logic.GetByUserAsync(userId).ConfigureAwait(false);
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
