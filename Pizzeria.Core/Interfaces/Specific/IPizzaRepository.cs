using System.Collections;
using System.Collections.Generic;
using Pizzeria.Core.HelperClasses;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Interfaces.Specific
{
    public interface IPizzaRepository:IRepository<Pizza>
    {
        IEnumerable<Pizza> GetAllPizzasByType(string type);
        Pizza GetPizzaByIdWithIngredients(int id);
        IEnumerable<Pizza> GetAllPizzasWithIngredients(PizzaParameters parameters);

    }
}