using Dawn;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WeAreMadeToHeal.Helpers.Auth;

namespace WeAreMadeToHeal.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        protected readonly ILogger<AuthController> _logger;
        private IAuthenticationLogic _logic { get; set; }
        public AuthController( IAuthenticationLogic logic, ILogger<AuthController> logger)
        {
            _logic = logic;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            Guard.Argument(loginModel.Username, nameof(loginModel.Username));
            Guard.Argument(loginModel.Password, nameof(loginModel.Password));
            try
            {
                
                var result = await this._logic.Login(loginModel.Username, loginModel.Password).ConfigureAwait(false);
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
