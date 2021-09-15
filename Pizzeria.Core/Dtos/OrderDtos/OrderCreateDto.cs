using System.Collections.Generic;
using Pizzeria.Core.Models.JoinTables;

namespace Pizzeria.Core.Dtos.OrderDtos
{
    public class OrderCreateDto
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        //public DateTime OrderedAt { get; set; }
        //public bool Priority { get; set; }
        public string PaymentOption { get; set; }
        public int? NumberOfPersons { get; set; }
        
        public List<OrderPizza> OrderPizzas { get; set; }
        public List<OrderDrink> OrderDrinks { get; set; }
    }
}