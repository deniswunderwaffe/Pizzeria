using Microsoft.Extensions.DependencyInjection;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Interfaces.Specific;
using Pizzeria.Infrastructure.Data.RepositoryImplementations;
using Pizzeria.Infrastructure.Data.RepositoryImplementations.SpecificImplementations;

namespace Pizzeria.Web.DependencyInjectionExtensions
{
    public static class RepositoryDependencyGroupExtensions
    {
        public static IServiceCollection AddRepositoryDependencyGroup(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IFoodItemRepository, FoodItemRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}