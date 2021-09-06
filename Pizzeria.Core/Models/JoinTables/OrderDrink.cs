using Pizzeria.Core.Models.Drinks;

namespace Pizzeria.Core.Models.JoinTables
{
    public class OrderDrink:BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        
        public int DrinkId { get; set; }
        public Drink Drink { get; set; }
    }
}