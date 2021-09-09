using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Interfaces
{
    public interface IPizzaService
    {
        public bool SaveAll();
        Pizza GetPizzaById(int id);
        Pizza FirstOrDefault(Expression<Func<Pizza, bool>> predicate);
        void AddPizza(Pizza entity);
        void UpdatePizza(Pizza entity);
        void RemovePizza(Pizza entity);
        IEnumerable<Pizza> GetAllPizzas();
        int CountAllPizzas();
        IEnumerable<Pizza> GetAllPizzasByType(string type);
        Pizza GetPizzaByIdWithIngredients(int id);
        IEnumerable<Pizza> GetAllPizzasWithIngredients();
    }
}