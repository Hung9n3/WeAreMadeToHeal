﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WeAreMadeToHeal.Extensions;

namespace WeAreMadeToHeal.Customer
{
    public class TagController : BaseCustomerController<Tag, ITagLogic>
    {
        public TagController(ILogger<BaseCustomerController<Tag, ITagLogic>> logger, LogicContext logicContext, ITagLogic logic) : base(logger, logicContext, logic)
        {
        }

        #region [ Public Methods - Single ]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> GetAsync(string id)
        {
            try
            {
                var result = await this._logic.GetAsync(id).ConfigureAwait(false);
                if (result == null || result.IsActive == false)
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

        #region [ Public Methods - List ]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await this._logic.GetActiveAsync().ConfigureAwait(false);
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
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> GetBatchAsync([FromBody] List<string> entityIds)
        {
            try
            {
                var result = await this._logic.GetBatchAsync(entityIds).ConfigureAwait(false);
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
        #endregion
    }
}
