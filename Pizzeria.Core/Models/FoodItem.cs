using System.Collections.Generic;
using Pizzeria.Core.Models.JoinTables;


namespace Pizzeria.Core.Models
{
    public class FoodItem:BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public int FoodCategoryId { get; set; }
        public FoodCategory FoodCategory { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<OrderFoodItem> OrderFoodItems { get; set; }
    }
}