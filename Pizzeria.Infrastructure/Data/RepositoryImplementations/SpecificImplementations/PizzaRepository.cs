using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public Pizza GetByIdWithIngredients(int id)
        {
            return _db.Pizzas.Where(x => x.Id == id)
                .Include(x => x.Ingredients)
                .FirstOrDefault();
        }
    }
}