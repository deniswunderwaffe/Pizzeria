namespace Pizzeria.Core.Models.JoinTables
{
    public class OrderFoodItem : BaseEntity
    {
        public int FoodItemId { get; set; }
        public FoodItem FoodItem { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int Quantity { get; set; }
    }
}