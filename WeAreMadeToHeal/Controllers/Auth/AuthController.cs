using AutoMapper;
using Dawn;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
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
using WeAreMadeToHeal.Helpers.Email;

namespace WeAreMadeToHeal.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        protected readonly ILogger<AuthController> _logger;
        private IAuthenticationLogic _logic { get; set; }
        private IMapper _mapper { get; set; }
        private readonly EmailHelper _emailHelper;
        public AuthController(IAuthenticationLogic logic, ILogger<AuthController> logger, EmailHelper emailHelper, IMapper mapper)
        {
            _logic = logic;
            _logger = logger;
            _mapper = mapper;
            _emailHelper = emailHelper;
        }

        [HttpPost("login")]
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
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            Guard.Argument(model.UserName, nameof(model.UserName));
            Guard.Argument(model.Password, nameof(model.Password));
            try
            {
                var user = _mapper.Map<User>(model);
                var result = await this._logic.Register(user, model.Password).ConfigureAwait(false);
                await SendConfirmationEmail(result);
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

        private async Task SendConfirmationEmail(User user)
        {
            var validEmailToken = this._logic.GetValidEmailToken(user);

            var baseUrl = $"{Request.Scheme}://{Request.Host.Value}{Request.PathBase.Value}";
            string confirmUrl = $"{baseUrl}/api/auth/confirm-email?guid={user.Id}&token={validEmailToken}";
                
            await _emailHelper.SendMail(
                destination: user!.Email,
                subject: $"Welcome {user.Name} to WeAreMadeToHeal",
                body: $"Click here to confirm your email: {confirmUrl}");
        }
    }
}
