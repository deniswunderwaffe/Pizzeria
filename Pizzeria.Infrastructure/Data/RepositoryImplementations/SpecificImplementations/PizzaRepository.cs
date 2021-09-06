using System.Collections.Generic;
using System.Linq;
using Pizzeria.Core.Interfaces.Specific;
using Pizzeria.Core.Models;

namespace Pizzeria.Infrastructure.Data.SpecificImplementations
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
    }
}