namespace Pizzeria.Core.Models.JoinTables
{
    public class OrderFoodItemExtra : BaseEntity
    {
        public FoodItemExtra FoodItemExtra { get; set; }
        public int FoodItemExtraId { get; set; }

        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}