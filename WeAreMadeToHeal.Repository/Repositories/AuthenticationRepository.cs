using Dawn;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal;

public class AuthenticationRepository : IAuthenticationRepository
{
    private readonly IUserRepository _userRepository;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AuthenticationRepository(IUserRepository userRepository, UserManager<User> userManager, SignInManager<User> signInManager)
    {
        _userRepository = userRepository;
        _userManager = userManager;
        _signInManager = signInManager;
    }
    public async Task<User> Login(string username, string password)
    {
        try
        {
            var user = new User();
            Guard.Argument(username, nameof(username));

            //check if receive email or username
            if (username.Contains("@") && username.Contains("."))
            {
                user = await _userRepository.GetByEmail(username);
            }
            else user = await _userRepository.GetByUsername(username);

            Guard.Argument(user, $"Login failed: Check your Username and Password");
            Guard.Argument(password, $"Login failed: Check your Username and Password");

            var passwordCheck = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (passwordCheck.Succeeded)
                return user;
            else throw new ArgumentNullException($"Login failed: Check your Username and Password");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task<User> Register(string username, string password)
    {
        try
        {
            Guard.Argument(username, nameof(username));
            var user = new User()
            {
                UserName = username,
            };
            Guard.Argument(password, nameof(password));

            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
                return user;
            else 
            {
                var error = string.Join(Environment.NewLine, result.Errors.Select(e => e.Description));
                throw new ArgumentNullException($"Unable to create user {user.UserName}. Result details: {result}");
            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
