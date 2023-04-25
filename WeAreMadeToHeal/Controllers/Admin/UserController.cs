using Microsoft.AspNetCore.Mvc;
using WeAreMadeToHeal.Enums;

namespace WeAreMadeToHeal.Admin
{
    [ApiController]
    //[Authorize(Roles = "Admin")]
    [Route("api/v{version:apiVersion}/admin/[controller]")]
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _logic;
        private ILogger<UserController> _logger;
        public UserController(IUserManager logic, ILogger<UserController> logger)
        {
            _logic = logic;
            _logger = logger;
        }

        #region [ Public Methods - Add | Update | Delete ]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> AddAsync([FromBody] User entity)
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

        //[HttpPut]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public virtual async Task<IActionResult> UpdateAsync([FromBody] User entity)
        //{
        //    try
        //    {
        //        await this._logic.UpdateAsync(entity).ConfigureAwait(false);
        //        return base.Ok();
        //    }
        //    catch (ArgumentNullException ex)
        //    {
        //        this._logger.LogError(ex, "Error in {0}", "");
        //        return base.BadRequest();
        //    }
        //    catch (Exception ex)
        //    {
        //        this._logger.LogError(ex, "Error in {0}", "");
        //        return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        //    }
        //}

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

        #region [ Public Methods - Activate ]
        [HttpPut("{id}/{isActive}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> ActivateOrDeactiveAsync(string id, bool isActive)
        {
            try
            {
                await this._logic.ActivateOrDeactiveAsync(id, isActive).ConfigureAwait(false);
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
                var result = await this._logic.GetAllAsync().ConfigureAwait(false);
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

        [HttpGet("{isActive}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public virtual async Task<IActionResult> GetActiveOrInActiveAsync(bool isActive)
        {
            try
            {
                var result = await this._logic.GetActiveOrInActiveAsync(isActive).ConfigureAwait(false);
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

        #region [ Custom Method Return Single ]
        [HttpGet("{username}/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByUsernameOrEmail(string username, string email)
        {
            try
            {
                string payload = "";
                if(username != null)
                {
                    payload = username;
                }
                else payload = email;

                var result = await this._logic.GetByUsernameOrEmail(payload).ConfigureAwait(false);
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

        #region [Custom Method Return List]
        [HttpGet("email/{isConfirmed}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUnConfirmOrConfirmedEmail(bool isConfirmed)
        {
            try
            {

                var result = await this._logic.GetUnConfirmOrConfirmedEmail(isConfirmed).ConfigureAwait(false);
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

        [HttpGet("phone/{isConfirmed}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUnConfirmOrConfirmedPhone(bool isConfirmed)
        {
            try
            {

                var result = await this._logic.GetUnConfirmOrConfirmedPhone(isConfirmed).ConfigureAwait(false);
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

        [HttpGet("name/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByName(string name)
        {
            try
            {

                var result = await this._logic.GetByName(name).ConfigureAwait(false);
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

        [HttpGet("role/{role}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByRole(UserRoles role)
        {
            try
            {

                var result = await this._logic.GetByRole(role).ConfigureAwait(false);
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
