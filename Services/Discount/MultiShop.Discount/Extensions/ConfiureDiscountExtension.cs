using MultiShop.Discount.Context;
using MultiShop.Discount.Services.Discount;

namespace MultiShop.Discount.Extensions
{
    public static class ConfiureDiscountExtension
    {
       public static void ConfiureExtension(this IServiceCollection services)
        {
            services.AddTransient<DapperContext>();
            services.AddScoped<IDiscountService, DiscountService>();

        }
    }
}
