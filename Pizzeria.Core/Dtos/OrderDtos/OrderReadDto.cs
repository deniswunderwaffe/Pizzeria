using System;
using System.Collections.Generic;
using Pizzeria.Core.Dtos.FoodItemDtos;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Dtos.OrderDtos
{
    public class OrderReadDto
    {
        public int Id { get; set; }
        public DateTime OrderedAt { get; set; }
        public DateTime DesiredDeliveryDateTime { get; set; }
        public Guid OrderIdentifier { get; set; }
        public string Note { get; set; }
        public decimal TotalPrice { get; set; }
        public bool? IsCash { get; set; }
        
        public Customer Customer { get; set; }
        
        public PromotionalCode PromotionalCode { get; set; }
        
        public OrderStatus OrderStatus { get; set; }

        public ICollection<FoodItemReadDto> FoodItems { get; set; }
    }
}