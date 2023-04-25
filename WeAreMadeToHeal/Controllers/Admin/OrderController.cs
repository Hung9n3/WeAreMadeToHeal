using Dawn;
using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal.Admin
{
    public class OrderController : BaseAdminController<Order, IOrderLogic>
    {
        public OrderController(ILogger<BaseAdminController<Order, IOrderLogic>> logger, ExcelHandlerService excelHandlerService, LogicContext logicContext, IOrderLogic logic) : base(logger, excelHandlerService, logicContext, logic)
        {
        }
        #region [ Custom Methods - List ]
        [HttpGet("{startDate}/{endDate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> GetByTimeInterval(DateTime startTime, DateTime endTime)
        {
            try
            {
                var result = await this._logic.GetByTimeInterval(startTime, endTime).ConfigureAwait(false);
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
        
        [HttpGet("userId")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> GetByUserAsync(string userId)
        {
            Guard.Argument(userId, nameof(userId));
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
