using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal.Admin
{
    public class OrderItemController : BaseAdminController<OrderItem, IOrderItemLogic>
    {
        public OrderItemController(ILogger<BaseAdminController<OrderItem, IOrderItemLogic>> logger, ExcelHandlerService excelHandlerService, LogicContext logicContext, IOrderItemLogic logic) : base(logger, excelHandlerService, logicContext, logic)
        {
        }

        #region [ Public Methods - List ]
        [HttpGet("{orderId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> GetByOrderAsync(string orderId)
        {
            try
            {
                var result = await this._logic.GetByOrderAsync(orderId).ConfigureAwait(false);
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
