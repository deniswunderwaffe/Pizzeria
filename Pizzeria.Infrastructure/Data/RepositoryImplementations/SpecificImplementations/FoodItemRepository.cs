using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Core.HelperClasses;
using Pizzeria.Core.Interfaces.Specific;
using Pizzeria.Core.Models;

namespace Pizzeria.Infrastructure.Data.RepositoryImplementations.SpecificImplementations
{
    public class FoodItemRepository:EfRepository<FoodItem>,IFoodItemRepository
    {
        public FoodItemRepository(ApplicationDbContext db) : base(db)
        {
        }

        public IEnumerable<FoodItem> FoodItemsByCategory(CategoryHelper.FoodCategories category)
        {
            return _db.FoodItems.Where(x => x.FoodCategory.Name == category.ToString());
        }

        public FoodItem GetFoodItemById(int id)
        {
            var foodItem = _db.FoodItems.AsNoTracking()
                .Include(x => x.FoodCategory)
                .FirstOrDefault(x => x.Id == id);
            return foodItem;
        }
    }
}