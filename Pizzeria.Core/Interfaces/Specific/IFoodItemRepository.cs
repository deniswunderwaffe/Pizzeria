using System.Collections.Generic;
using Pizzeria.Core.HelperClasses;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Interfaces.Specific
{
    public interface IFoodItemRepository : IRepository<FoodItem>
    {
        IEnumerable<FoodItem> FoodItemsByCategory(CategoryHelper.FoodCategories category);
        FoodItem GetFoodItemById(int id);
    }
}