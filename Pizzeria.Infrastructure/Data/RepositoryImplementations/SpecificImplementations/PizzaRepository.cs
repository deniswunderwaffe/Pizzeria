using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Core.HelperClasses;
using Pizzeria.Core.HelperClasses.Paging;
using Pizzeria.Core.Interfaces.Specific;
using Pizzeria.Core.Models;

namespace Pizzeria.Infrastructure.Data.RepositoryImplementations.SpecificImplementations
{
    public class PizzaRepository:EfRepository<Pizza>,IPizzaRepository
    {
        public PizzaRepository(ApplicationDbContext db) : base(db)
        {
        }

        public IEnumerable<Pizza> GetAllPizzasByType(string type)
        {
            return _db.Pizzas.Where(x => x.Type == type);
        }

        public Pizza GetPizzaByIdWithIngredients(int id)
        {
            return _db.Pizzas.Where(x => x.Id == id)
                .Include(x => x.Ingredients)
                .FirstOrDefault();
        }

        public PagedList<Pizza> GetAllPizzasWithIngredients(PizzaParameters parameters)
        {
            return PagedList<Pizza>.ToPagedList(_db.Pizzas
                    .Include(x => x.Ingredients)
                    .OrderBy(on => on.Name),
                parameters.PageNumber,
                parameters.PageSize);
            
        }
    }
}