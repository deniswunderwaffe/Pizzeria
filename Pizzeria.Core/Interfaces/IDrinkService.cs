using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Pizzeria.Core.HelperClasses.Paging;
using Pizzeria.Core.Models.Drinks;

namespace Pizzeria.Core.Interfaces
{
    public interface IDrinkService
    {
        public bool SaveAll();
        Drink GetDrinkById(int id);
        Drink FirstOrDefault(Expression<Func<Drink, bool>> predicate);
        void AddDrink(Drink entity);
        void UpdateDrink(Drink entity);
        void RemoveDrink(Drink entity);
        PagedList<Drink> GetAllDrinks(DrinkParameters parameters);
        int CountAllDrinks();
    }
}