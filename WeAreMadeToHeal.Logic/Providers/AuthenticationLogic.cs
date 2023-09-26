using Dawn;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Web;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using System.Net.Http;


namespace WeAreMadeToHeal;


public class AuthenticationLogic : IAuthenticationLogic
{
    private readonly IAuthenticationRepository _dataProvider;
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthenticationLogic(IAuthenticationRepository dataProvider, IConfiguration configuration, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
    {
        _dataProvider = dataProvider;
        _configuration = configuration;
        _userManager = userManager;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<string> Login(string username, string password)
    {
        try
        {
            Guard.Argument(username, "username is null");
            Guard.Argument(password, "Password is null");
            var user = await _dataProvider.Login(username, password);

            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", user.Id.ToString()),
                        new Claim("DisplayName", user.Name),
                        new Claim("Email", user.Email),
                        //new Claim(ClaimTypes.Role, user.Role.ToString())
                    };

            // generate token that is valid for ExpiredToken days
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AppSettings:SecretKey"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(int.Parse(_configuration["AppSettings:ExpiredDay"])),
                signingCredentials: signIn);

            var result = new JwtSecurityTokenHandler().WriteToken(token);
            return result;

        }
        catch (ArgumentNullException ex) 
        {
            throw new ArgumentNullException(ex.Message);
        }

        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    
    public Task<User> Register(User user, string password)
    {
        try
        {
            Guard.Argument(user.UserName, "username is null");
            Guard.Argument(password, "password is null");
            var result = _dataProvider.Register(user, password);

            return result;
        }
        catch (ArgumentNullException ex)
        {
            throw new ArgumentNullException(ex.Message);
        }

        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<string> GetValidEmailToken(User user)
    {
        var confirmEmailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var validEmailToken = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(confirmEmailToken));

        return validEmailToken;
    }
}
