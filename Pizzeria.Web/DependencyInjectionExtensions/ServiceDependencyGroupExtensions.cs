using Microsoft.Extensions.DependencyInjection;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Services;

namespace Pizzeria.Web.DependencyInjectionExtensions
{
    public static class ServiceDependencyGroupExtensions
    {
        public static IServiceCollection AddServiceDependencyGroup(this IServiceCollection services)
        {
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPromotionalCodeService, PromotionalCodeService>();
            services.AddScoped<IFoodItemExtraService, FoodItemExtraService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IFoodItemService, FoodItemService>();
            return services;
        }
    }
}