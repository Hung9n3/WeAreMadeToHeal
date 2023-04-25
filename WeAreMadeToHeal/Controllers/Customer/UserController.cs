using Microsoft.AspNetCore.Mvc;

namespace WeAreMadeToHeal.Customer
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/customer/[controller]")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UserController : ControllerBase
    {
        protected readonly ILogger<UserController> _logger;
        protected readonly LogicContext _userManagerContext;
        protected readonly UserManager _userManager;
        public UserController(ILogger<UserController> logger, LogicContext logicContext, UserManager userManager)
        {
            _logger = logger;
            _userManagerContext = logicContext;
            _userManager = userManager;
        }

        #region [ Public Methods - Add | Update | Delete ]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> UpdateAsync([FromBody] User entity)
        {
            try
            {
                await this._userManager.UpdateAsync(entity).ConfigureAwait(false);
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

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> DeleteAsync()
        {
            try
            {
                var userId = User.Claims.First(c => c.Type == "UserId").Value;
                await this._userManager.DeleteAsync(userId).ConfigureAwait(false);
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

        #region [ Public Methods - Activate ]
        [HttpPut("{isActive}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> ActivateOrDeactiveAsync(bool isActive)
        {
            try
            {
                var userId = User.Claims.First(c => c.Type == "UserId").Value;
                await this._userManager.ActivateOrDeactiveAsync(userId, isActive).ConfigureAwait(false);
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

        #region [ Public Methods - Single ]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> GetAsync()
        {
            try
            {
                var userId = User.Claims.First(c => c.Type == "UserId").Value;

                var result = await this._userManager.GetAsync(userId).ConfigureAwait(false);
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

        #region [ Custom Method Void ]
        #endregion

    }
}
