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
        public static void AddLogic(this IServiceCollection services)
        {
            services.AddScoped<LogicContext>();

            services.AddTransient<IUserManager, UserManager>();
            services.AddTransient<ITagLogic, TagLogic>();
            services.AddTransient<IProductLogic, ProductLogic>();
            services.AddTransient<ICouponUserLogic, CouponUserLogic>();
            services.AddTransient<ICouponLogic, CouponLogic>();
            services.AddTransient<ICartItemLogic, CartItemLogic>();
            services.AddTransient<IOrderLogic, OrderLogic>();
            services.AddTransient<ICategoryLogic, CategoryLogic>();
            services.AddTransient<IBankCardLogic, BankCardLogic>();
            services.AddTransient<IOrderItemLogic, OrderItemLogic>();
            services.AddTransient<IImageLogic, ImageLogic>();
            services.AddTransient<IAuthenticationLogic, AuthenticationLogic>();

        }
    }
}
