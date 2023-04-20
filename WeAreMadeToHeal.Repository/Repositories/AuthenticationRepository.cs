using Dawn;
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
    public AuthenticationRepository(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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

            if (user == null)
            {
                throw new ArgumentNullException($"Login failed: Check your Username and Password");
            }
            Guard.Argument(password, nameof(password));
            if (user.Password == password) return user;
            else throw new ArgumentNullException($"Login failed: Check your Username and Password");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
