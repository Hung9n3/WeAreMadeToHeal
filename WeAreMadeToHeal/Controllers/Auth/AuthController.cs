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
        private UserManager<User> _userManager { get; set; }
        private RoleManager<Role> _roleManager { get; set; }
        private readonly AppSettings _appSettings;
        private WRMTHDbContext _context { get; set; }
        public AuthController(UserManager<User> user, RoleManager<Role> role, WRMTHDbContext context, IOptions<AppSettings> appSettings)
        {
            _userManager = user;
            _roleManager = role;
            _appSettings = appSettings.Value;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login(User loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.Username);
            IList<string> role = await _userManager.GetRolesAsync(user);
            IList<Claim> Claims = await _userManager.GetClaimsAsync(user);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                List<Claim> claims = new List<Claim> {
                    new Claim("UserId", user.Id.ToString()),
                };
                foreach (string r in role)
                {
                    claims.Add(new Claim(ClaimTypes.Role, r));
                };
                foreach (Claim c in Claims)
                {
                    claims.Add(c);
                };
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.SecretKey)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
        }
    }
}
