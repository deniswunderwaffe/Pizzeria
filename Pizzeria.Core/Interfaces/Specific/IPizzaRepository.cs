
using System.Collections.Generic;
using Pizzeria.Core.HelperClasses.Paging;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Interfaces.Specific
{
    public interface IPizzaRepository:IRepository<Pizza>
    {
        IEnumerable<Pizza> GetAllPizzasByType(string type);
        Pizza GetPizzaByIdWithIngredients(int id);
        PagedList<Pizza> GetAllPizzasWithIngredients(PizzaParameters parameters);

    }
}