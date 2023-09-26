using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Bcpg;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal;

public static class ServiceExtensions
{
    public static void AddPolicy(this IServiceCollection services)
    { 
        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
            options.AddPolicy("Customer", policy => policy.RequireRole("Customer"));
        });
    }
    
    public static void AddJwtBearer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(option =>
        {
            option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(option =>
            {
                option.RequireHttpsMetadata = false;
                option.SaveToken = false;
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AppSettings:SecretKey"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };

                option.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        // Custom logic when token authentication fails
                        // For example, you can log the error or handle it in a specific way
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        // Custom logic after the token is successfully validated
                        // Access the validated claims using context.Principal.Claims
                        var dbContext = context.HttpContext.RequestServices.GetRequiredService<WRMTHDbContext>();
                        var userId = context.Principal.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
                        if (userId.IsNullOrEmpty())
                        {
                            return Task.CompletedTask;
                        }
                        var role = dbContext.Users.FirstOrDefault(x => x.Id == userId)?.Role.ToString();
                        if (!string.IsNullOrEmpty(role))
                        {
                            var claimsIdentity = (ClaimsIdentity)context.Principal.Identity;
                            var claim = new Claim(ClaimTypes.Role, role);
                            claimsIdentity.AddClaim(claim);
                        }
                        // Perform additional processing or checks based on the claims
                        // For example, you can add custom authorization logic or enrich the current user's identity
                        return Task.CompletedTask;
                    }
                };
            });
    }

    public static void AddIdentity(this IServiceCollection services)
    {
       services.AddIdentity<User, Role>(options =>
        {
            options.User.RequireUniqueEmail = true;

            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 1;

            options.User.RequireUniqueEmail = false;
            options.SignIn.RequireConfirmedEmail = false;
        })
            .AddEntityFrameworkStores<WRMTHDbContext>()
            .AddUserManager<UserManager>()
            .AddDefaultTokenProviders();
    }
}
