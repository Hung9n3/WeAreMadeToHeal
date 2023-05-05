using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using WeAreMadeToHeal;
using WeAreMadeToHeal.Helpers.Email;

namespace WeAreMadeToHeal.Helpers;

public static class ServiceExtensions
{
    public static void AddHelpers(this IServiceCollection services)
    {
        services.AddTransient<EmailConfig>();
        services.AddTransient<EmailHelper>();
        services.AddTransient<ExcelHandlerService>();

        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });
        IMapper mapper = mapperConfig.CreateMapper();
        services.AddSingleton(mapper);
    }
}
