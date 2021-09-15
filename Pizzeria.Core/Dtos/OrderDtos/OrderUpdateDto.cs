using System;
using System.Collections.Generic;
using Pizzeria.Core.Dtos.DrinkDtos;
using Pizzeria.Core.Dtos.PizzaDtos;
using Pizzeria.Core.Models.JoinTables;

namespace Pizzeria.Core.Dtos.OrderDtos
{
    public class OrderUpdateDto
    {
        public string Phone { get; set; }
        public string PaymentOption { get; set; }

        public List<OrderPizza> OrderPizzas { get; set; }
        public List<OrderDrink> OrderDrinks { get; set; }
    }
}