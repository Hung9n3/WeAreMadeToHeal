﻿using Dawn;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal.Customer
{
    public class ProductController : BaseCustomerController<Product, IProductLogic>
    {
        public ProductController(ILogger<BaseCustomerController<Product, IProductLogic>> logger, ExcelHandlerService excelHandlerService, LogicContext logicContext, IProductLogic logic) : base(logger, excelHandlerService, logicContext, logic)
        {
        }

        #region [Custom Method Return Single]
        [HttpGet("{id}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> GetAsync(string id)
        {
            try
            {
                var result = await this._logic.GetAsync(id).ConfigureAwait(false);
                if (result == null||!result.IsActive)
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

        #region [Custom Method Return List]
        [HttpGet("category/{cateId}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> GetByCategory(string cateId)
        {
            Guard.Argument(cateId, nameof(cateId));
            try
            {
                var result = await this._logic.GetByCategory(cateId).ConfigureAwait(false);
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

        [HttpGet("tag/{tagId}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> GetByTag(string tagId)
        {
            Guard.Argument(tagId, nameof(tagId));

            try
            {
                var result = await this._logic.GetByTag(tagId).ConfigureAwait(false);
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

        [HttpGet("color/{colorCode}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> GetByColor(string colorCode)
        {
            Guard.Argument(colorCode, nameof(colorCode));

            try
            {
                var result = await this._logic.GetByColor(colorCode).ConfigureAwait(false);
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

        [HttpGet("size/{size}")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> GetBySize(string size)
        {
            Guard.Argument(size, nameof(size));

            try
            {
                var result = await this._logic.GetBySize(size).ConfigureAwait(false);
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

        [HttpGet]
        [AllowAnonymous]
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
        [HttpPost]
        [AllowAnonymous]
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
