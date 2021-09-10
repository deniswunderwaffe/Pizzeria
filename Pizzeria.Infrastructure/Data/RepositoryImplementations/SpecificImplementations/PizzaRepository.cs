using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;

using Pizzeria.Core.HelperClasses.Paging;
using Pizzeria.Core.HelperClasses.Sorting;
using Pizzeria.Core.Interfaces.Specific;
using Pizzeria.Core.Models;

namespace Pizzeria.Infrastructure.Data.RepositoryImplementations.SpecificImplementations
{
    public class PizzaRepository:EfRepository<Pizza>,IPizzaRepository
    {
        private readonly ISortHelper<Pizza> _sortHelper;
        public PizzaRepository(ApplicationDbContext db, ISortHelper<Pizza> sortHelper) : base(db)
        {
            _sortHelper = sortHelper;
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
            var pizza = _db.Pizzas
                .Include(x => x.Ingredients)
                .OrderBy(on => on.Id)
                .AsQueryable();
            
            if (!string.IsNullOrEmpty(parameters.Type)) pizza =  pizza.Where(x => x.Type == parameters.Type);
            pizza =  pizza.Where(x => x.Price >= parameters.MinPrice && x.Price <=parameters.MaxPrice); 

            var sortedPizza = _sortHelper.ApplySort(pizza, parameters.OrderBy);
            return PagedList<Pizza>.ToPagedList(sortedPizza,
                parameters.PageNumber,
                parameters.PageSize);
            
        }
    }
}