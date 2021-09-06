
using System;
using System.Collections.Generic;
using Pizzeria.Core.Models.Drinks;
using Pizzeria.Core.Models.JoinTables;

namespace Pizzeria.Core.Models
{
    public class Order:BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime OrderedAt { get; set; }
        public bool Priority { get; set; }
        public string PaymentOption { get; set; }
        public int? NumberOfPersons { get; set; }
        
        public ICollection<Pizza> Pizzas { get; set; }
        public ICollection<Drink> Drinks { get; set; }
        
        public List<OrderPizza> OrderPizzas { get; set; }
        public List<OrderDrink> OrderDrinks { get; set; }
    }
}