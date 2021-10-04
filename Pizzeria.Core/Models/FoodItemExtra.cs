using System.Collections.Generic;
using Pizzeria.Core.Models.JoinTables;

namespace Pizzeria.Core.Models
{
    public class FoodItemExtra : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public int? FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; }

        public ICollection<OrderFoodItem> OrderFoodItems { get; set; }
        public ICollection<OrderFoodItemExtra> OrderFoodItemExtras { get; set; }
    }
}