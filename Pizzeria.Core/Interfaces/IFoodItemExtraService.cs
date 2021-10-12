using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Interfaces
{
    public interface IFoodItemExtraService
    {
        public bool SaveAll();
        FoodItemExtra GetFoodItemExtraById(int id);
        FoodItemExtra FirstOrDefault(Expression<Func<FoodItemExtra, bool>> predicate);
        void AddFoodItemExtra(FoodItemExtra entity);
        void UpdateFoodItemExtra(FoodItemExtra entity);
        void RemoveFoodItemExtra(FoodItemExtra entity);
        int CountAllFoodItemExtras();
        IEnumerable<FoodItemExtra> GetExtrasForFoodItem(int id);
    }
}