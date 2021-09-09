using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Pizzeria.Core.Exceptions;
using Pizzeria.Core.HelperClasses;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Interfaces.Specific;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Services
{
    public class PizzaService:IPizzaService
    {
        private readonly IPizzaRepository _repository;

        public PizzaService(IPizzaRepository repository)
        {
            _repository = repository;
        }
        

        public bool SaveAll()
        {
            return  _repository.SaveAll();
        }

        public Pizza GetPizzaById(int id)
        {
            return _repository.GetById(id);
        }

        public Pizza FirstOrDefault(Expression<Func<Pizza, bool>> predicate)
        {
            return _repository.FirstOrDefault(predicate);
        }

        public void AddPizza(Pizza entity)
        {
            if (!PizzaHelper.GetTypes().Contains(entity.Type))
            {
                throw new InvalidPizzaTypeException("This type of pizza is not supported");
            }
            _repository.Add(entity);
        }

        public void UpdatePizza(Pizza entity)
        {
            _repository.Update(entity);
        }

        public void RemovePizza(Pizza entity)
        {
            _repository.Remove(entity);
        }

        public IEnumerable<Pizza> GetAllPizzas()
        {
            return _repository.GetAll();
        }

        public int CountAllPizzas()
        {
            return _repository.CountAll();
        }

        public IEnumerable<Pizza> GetAllPizzasByType(string type)
        {
            return _repository.GetAllPizzasByType(type);
        }

        public Pizza GetPizzaByIdWithIngredients(int id)
        {
            return _repository.GetPizzaByIdWithIngredients(id);
        }

        public IEnumerable<Pizza> GetAllPizzasWithIngredients()
        {
            return _repository.GetAllPizzasWithIngredients();
        }
    }
}