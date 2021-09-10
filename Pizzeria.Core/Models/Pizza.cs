using System.Collections.Generic;
using Pizzeria.Core.Models.JoinTables;


namespace Pizzeria.Core.Models
{
    public class Pizza:BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        //TODO change to double
        public int Price { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Order> Orders { get; set; }
        
        public List<OrderPizza> OrderPizzas { get; set; }
        public List<PizzaIngredient> PizzaIngredient { get; set; }
    }
}