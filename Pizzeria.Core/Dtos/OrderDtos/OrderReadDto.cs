using System;
using System.Collections.Generic;
using Pizzeria.Core.Dtos.DrinkDtos;
using Pizzeria.Core.Dtos.PizzaDtos;


namespace Pizzeria.Core.Dtos.OrderDtos
{
    public class OrderReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime OrderedAt { get; set; }
        public bool Priority { get; set; }
        public string PaymentOption { get; set; }
        public int? NumberOfPersons { get; set; }
        
        public ICollection<PizzaReadDto> Pizzas { get; set; }
        public ICollection<DrinkReadDto> Drinks { get; set; }
    }
}