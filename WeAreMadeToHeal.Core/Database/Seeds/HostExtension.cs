using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal;

public static class HostExtension
{
    public static void SeedDataMiddleWare(this IHost host)
    {
        var _serviceProvider = host.Services.GetService<IServiceScopeFactory>();
        using (var scope = _serviceProvider.CreateScope())
        {
            var database = scope.ServiceProvider.GetService<DatabaseProvider>()!;
            database.CleanSeed().Wait();
            database.SeedData().Wait();
            //do your stuff....
        }
    }
}
