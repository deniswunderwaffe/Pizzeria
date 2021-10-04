using System;
using System.Collections.Generic;
using Pizzeria.Core.Models.JoinTables;


namespace Pizzeria.Core.Models
{
    public class Order:BaseEntity
    {
        public DateTime OrderedAt { get; set; }
        public DateTime DesiredDeliveryDateTime { get; set; }
        public Guid OrderIdentifier { get; set; }
        public string Note { get; set; }
        public decimal TotalPrice { get; set; }
        public bool? IsCash { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        
        public int? PromotionalCodeId { get; set; }
        public PromotionalCode PromotionalCode { get; set; }
        
        public int OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public ICollection<FoodItem> FoodItems { get; set; }
        public ICollection<OrderFoodItem> OrderFoodItems { get; set; }
    }
}