using Dawn;
using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal.Customer
{
    public class CartItemController : BaseCustomerController<CartItem, ICartItemLogic>
    {
        public CartItemController(ILogger<BaseCustomerController<CartItem, ICartItemLogic>> logger, ExcelHandlerService excelHandlerService, LogicContext logicContext, ICartItemLogic logic) : base(logger, excelHandlerService, logicContext, logic)
        {
        }


        #region [ Public Methods - Add | Update | Delete ]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> AddAsync([FromBody] CartItem entity)
        {
            try
            {
                await this._logic.AddAsync(entity).ConfigureAwait(false);
                return base.Ok();
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

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> UpdateAsync([FromBody] CartItem entity)
        {
            try
            {
                await this._logic.UpdateAsync(entity).ConfigureAwait(false);
                return base.Ok();
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

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> DeleteAsync(string id)
        {
            try
            {
                await this._logic.DeleteAsync(id).ConfigureAwait(false);
                return base.Ok();
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

        #region [ Public Methods - List ]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> GetByUserAsync()
        {
            try
            {
                var userId = User.Claims.First(c => c.Type == "UserId").Value;

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
