using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Pizzeria.Core.HelperClasses.Paging;
using Pizzeria.Core.HelperClasses.Sorting;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Models;
using Pizzeria.Core.Models.Drinks;

namespace Pizzeria.Core.Services
{
    public class DrinkService:IDrinkService
    {
        private readonly IRepository<Drink> _repository;
        private readonly ISortHelper<Drink> _sortHelper;

        public DrinkService(IRepository<Drink> repository, ISortHelper<Drink> sortHelper)
        {
            _repository = repository;
            _sortHelper = sortHelper;
        }

        public bool SaveAll()
        {
            return _repository.SaveAll();
        }

        public Drink GetDrinkById(int id)
        {
            return _repository.GetById(id);
        }

        public Drink FirstOrDefault(Expression<Func<Drink, bool>> predicate)
        {
            return _repository.FirstOrDefault(predicate);
        }

        public void AddDrink(Drink entity)
        {
            _repository.Add(entity);
            SaveAll();
        }

        public void UpdateDrink(Drink entity)
        {
            _repository.Update(entity);
            SaveAll();
        }

        public void RemoveDrink(Drink entity)
        {
            _repository.Remove(entity);
            SaveAll();
        }

        public PagedList<Drink> GetAllDrinks(DrinkParameters parameters)
        {
            var drinks = _repository.GetAllQueryable();
            
            if (!string.IsNullOrEmpty(parameters.Brand)) drinks =  drinks.Where(x => x.Brand == parameters.Brand);
            var sortedDrinks = _sortHelper.ApplySort(drinks, parameters.OrderBy);
            
            return PagedList<Drink>.ToPagedList(sortedDrinks, parameters.PageNumber, parameters.PageSize);
        }

        public int CountAllDrinks()
        {
            return _repository.CountAll();
        }
    }
}