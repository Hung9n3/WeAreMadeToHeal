using System.Runtime.CompilerServices;

namespace WeAreMadeToHeal.Helpers.Auth.Authorize
{
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
    }
}
