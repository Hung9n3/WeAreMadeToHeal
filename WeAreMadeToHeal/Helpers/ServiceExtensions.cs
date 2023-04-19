using WeAreMadeToHeal;
using WeAreMadeToHeal.Helpers.Email;

namespace WeAreMadeToHeal;

public class ServiceExtensions
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<EmailConfig>();
        services.AddTransient<EmailHelper>();
        services.AddTransient<ExcelHandlerService>();
    }
}
