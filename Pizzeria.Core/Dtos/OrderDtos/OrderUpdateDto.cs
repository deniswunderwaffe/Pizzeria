using System;
using System.Collections.Generic;
using Pizzeria.Core.Dtos.DrinkDtos;
using Pizzeria.Core.Dtos.PizzaDtos;

namespace Pizzeria.Core.Dtos.OrderDtos
{
    public class OrderUpdateDto
    {
        public string Phone { get; set; }
        public string PaymentOption { get; set; }

        // public ICollection<PizzaReadDto> Pizzas { get; set; }
        // public ICollection<DrinkReadDto> Drinks { get; set; }
    }
}