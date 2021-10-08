using System.Linq;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.HelperClasses
{
    public static class OrderIncludeQueryableExtension
    {
        public static IQueryable<Order> OrderAllIncludes(this IQueryable<Order> source)
        {
            return source.AsSplitQuery()
                .Include(x => x.Customer)
                .Include(x => x.FoodItems)
                .Include(x => x.OrderFoodItems)
                .Include(x => x.FoodItemExtras)
                .Include(x => x.OrderStatus)
                .Include(x => x.PromotionalCode);
        }
    }
}