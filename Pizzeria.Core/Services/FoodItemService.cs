using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Pizzeria.Core.HelperClasses;
using Pizzeria.Core.HelperClasses.Paging;
using Pizzeria.Core.HelperClasses.Sorting;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Interfaces.Specific;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Services
{
    public class FoodItemService:IFoodItemService
    {
        private readonly IFoodItemRepository _repository;
        private readonly ISortHelper<FoodItem> _sortHelper;

        public FoodItemService(IFoodItemRepository repository, ISortHelper<FoodItem> sortHelper)
        {
            _repository = repository;
            _sortHelper = sortHelper;
        }

        public bool SaveAll()
        {
            return _repository.SaveAll();
        }

        public FoodItem GetFoodItemById(int id)
        {
            var foodItem = _repository.GetFoodItemById(id);
            return foodItem;
        }

        public FoodItem FirstOrDefault(Expression<Func<FoodItem, bool>> predicate)
        {
            var foodItem = _repository.FirstOrDefault(predicate);
            return foodItem;
        }

        public void AddFoodItem(FoodItem entity)
        {
            _repository.Add(entity);
            SaveAll();
        }

        public void UpdateFoodItem(FoodItem entity)
        {
            _repository.Update(entity);
            SaveAll();
        }

        public void RemoveFoodItem(FoodItem entity)
        {
            _repository.Remove(entity);
            SaveAll();
        }

        public int CountAllFoodItems()
        {
            var count = _repository.CountAll();
            return count;
        }

        public IEnumerable<FoodItem> GetAllFoodItemsByCategory(CategoryHelper.FoodCategories category)
        {
            var foodItemsByCategory = _repository.FoodItemsByCategory(category);
            return foodItemsByCategory;
        }

        public PagedList<FoodItem> GetAllFoodPaged(FoodItemParameters parameters)
        {
            var foodItems = _repository.GetAllQueryable();
            if (!string.IsNullOrEmpty(parameters.Category))
            {
                foodItems = foodItems.Where(x => x.FoodCategory.Name == parameters.Category);
            }
            foodItems = foodItems.Where(x => x.Price >= parameters.MinPrice && x.Price <=parameters.MaxPrice);
            
            var sortedFoodItems = _sortHelper.ApplySort(foodItems, parameters.OrderBy);
            return PagedList<FoodItem>.ToPagedList(sortedFoodItems,
                parameters.PageNumber,
                parameters.PageSize);
        }
    }
}