using Pizzeria.Core.Models;
using Pizzeria.Core.Models.JoinTables;

namespace Pizzeria.Core.Models.JoinTables
{
    public class OrderFoodItemExtra:BaseEntity
    {
        public FoodItemExtra FoodItemExtra { get; set; }
        public int FoodItemExtraId { get; set; }
        
        public OrderFoodItem OrderFoodItem { get; set; }
        public int OrderFoodItemId { get; set; }

        public int Quantity { get; set; }
    }
}