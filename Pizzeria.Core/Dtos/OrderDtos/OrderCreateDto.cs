using System;
using System.Collections.Generic;
using Pizzeria.Core.Models.JoinTables;

namespace Pizzeria.Core.Dtos.OrderDtos
{
    public class OrderCreateDto
    {
        public DateTime DesiredDeliveryDateTime { get; set; }
        public string Note { get; set; }
        public bool? IsCash { get; set; }

        public int CustomerId { get; set; }

        public string PromotionalCode { get; set; }
        public ICollection<OrderFoodItem> OrderFoodItems { get; set; }
    }
}