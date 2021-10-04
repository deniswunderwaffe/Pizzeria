using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Pizzeria.Core.HelperClasses;
using Pizzeria.Core.HelperClasses.Paging;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Interfaces
{
    public interface IFoodItemService
    {
        public bool SaveAll();
        FoodItem GetFoodItemById(int id);
        FoodItem FirstOrDefault(Expression<Func<FoodItem, bool>> predicate);
        void AddFoodItem(FoodItem entity);
        void UpdateFoodItem(FoodItem entity);
        void RemoveFoodItem(FoodItem entity);
        int CountAllFoodItems();
        IEnumerable<FoodItem> GetAllFoodItemsByCategory(CategoryHelper.FoodCategories category);
        
        PagedList<FoodItem> GetAllFoodPaged(FoodItemParameters parameters);
    }
}