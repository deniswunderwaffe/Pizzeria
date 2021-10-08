using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Pizzeria.Core.Models.JoinTables;

namespace Pizzeria.Core.Dtos.OrderDtos
{
    public class OrderCreateDto
    {
        [Required] public DateTime DesiredDeliveryDateTime { get; set; }
        public string Note { get; set; }
        public bool? IsCash { get; set; }
        [Required] public int CustomerId { get; set; }
        [Required] public ICollection<OrderFoodItem> OrderFoodItems { get; set; }
        public ICollection<OrderFoodItemExtra> OrderFoodItemExtras { get; set; }
    }
}