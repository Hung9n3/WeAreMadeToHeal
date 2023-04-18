namespace WeAreMadeToHeal.Helpers.Email
{
    public class ServiceExtensions
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<EmailConfig>();
            services.AddTransient<EmailHelper>();
        }
    }
}
