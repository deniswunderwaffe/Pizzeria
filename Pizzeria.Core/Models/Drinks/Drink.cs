using System.Collections.Generic;
using Pizzeria.Core.Models.JoinTables;

namespace Pizzeria.Core.Models.Drinks
{
    public abstract class Drink:BaseEntity
    {
        public string Brand { get; set; }
        public string Name { get; set; }

        public ICollection<Order> Orders { get; set; }
        public List<OrderDrink> OrderDrinks { get; set; }
    }
}