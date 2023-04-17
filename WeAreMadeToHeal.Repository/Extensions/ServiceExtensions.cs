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
        public static void AddRepository(this IServiceCollection services)
        {
            //services.AddScoped<RepositoryContext>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITagRepository, TagRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICouponUserRepository, CouponUserRepository>();
            services.AddTransient<ICouponRepository, CouponRepository>();
            services.AddTransient<ICartItemRepository, CartItemRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IBankCardRepository, BankCardRepository>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();
            services.AddTransient<IImageRepository, ImageRepository>();

        }
        public static void AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepository();
        }
    }
}
