using Dawn;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeAreMadeToHeal
{
    public static class ServiceExtensions
    {
        public static void AddWRMTHDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionStringKey = "LocalConnection";
            var connectionString = configuration.GetConnectionString(connectionStringKey);
            Guard.Argument(connectionString, $"Connection string {connectionStringKey} is not set.");

            var options = new DbContextOptions<WRMTHDbContext>();
            var builder = new DbContextOptionsBuilder<WRMTHDbContext>(options);
            builder.UseSqlServer(connectionString);
            builder.EnableSensitiveDataLogging(false);

            services.AddDbContext<WRMTHDbContext>(options => {
                options.UseSqlServer(connectionString, sqlServerOptionsAction => {
                    sqlServerOptionsAction.EnableRetryOnFailure();
                });
                options.EnableSensitiveDataLogging();
            });
        }
    }
}
