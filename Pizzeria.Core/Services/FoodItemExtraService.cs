using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Services
{
    public class FoodItemExtraService : IFoodItemExtraService
    {
        private readonly IRepository<FoodItemExtra> _repository;

        public FoodItemExtraService(IRepository<FoodItemExtra> repository)
        {
            _repository = repository;
        }

        public bool SaveAll()
        {
            return _repository.SaveAll();
        }

        public FoodItemExtra GetFoodItemExtraById(int id)
        {
            var foodItemExtra = _repository.GetById(id);
            return foodItemExtra;
        }

        public FoodItemExtra FirstOrDefault(Expression<Func<FoodItemExtra, bool>> predicate)
        {
            var foodItemExtra = _repository.FirstOrDefault(predicate);
            return foodItemExtra;
        }

        public void AddFoodItemExtra(FoodItemExtra entity)
        {
            _repository.Add(entity);
            SaveAll();
        }

        public void UpdateFoodItemExtra(FoodItemExtra entity)
        {
            _repository.Update(entity);
            SaveAll();
        }

        public void RemoveFoodItemExtra(FoodItemExtra entity)
        {
            _repository.Remove(entity);
            SaveAll();
        }

        public int CountAllFoodItemExtras()
        {
            var count = _repository.CountAll();
            return count;
        }

        public IEnumerable<FoodItemExtra> GetExtrasForFoodItem(int id)
        {
            var extrasForFoodItem = _repository.FindByCondition(x => x.FoodItemId == id).AsEnumerable();
            return extrasForFoodItem;
        }
    }
}