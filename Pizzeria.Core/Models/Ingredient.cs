using System.Collections.Generic;
using Pizzeria.Core.Models.JoinTables;

namespace Pizzeria.Core.Models
{
    public class Ingredient:BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public ICollection<Pizza> Pizzas { get; set; }
        public List<PizzaIngredient> PizzaIngredient { get; set; }

        public int? ProviderId { get; set; }
        public Provider Provider { get; set; }
        
    }
}