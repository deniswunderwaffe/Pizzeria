using System;
using System.Collections.Generic;
using Pizzeria.Core.Models;
using Pizzeria.Core.Models.JoinTables;

namespace Pizzeria.Core.Dtos.OrderDtos
{
    public class OrderUpdateDto
    {
        public DateTime DesiredDeliveryDateTime { get; set; }
        public string Note { get; set; }
        public bool? IsCash { get; set; }
        public int? PromotionalCodeId { get; set; }
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ICollection<OrderFoodItem> OrderFoodItems { get; set; }
    }
}