using WeAreMadeToHeal;
using WeAreMadeToHeal.Helpers.Email;

namespace WeAreMadeToHeal;

public static class ServiceExtensions
{
    public static void AddHelpers(this IServiceCollection services)
    {
        services.AddTransient<EmailConfig>();
        services.AddTransient<EmailHelper>();
        services.AddTransient<ExcelHandlerService>();
    }
}
