using System.Collections.Generic;
using Pizzeria.Core.Models.JoinTables;

namespace Pizzeria.Core.Dtos.FoodItemDtos
{
    public class FoodItemExtraReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? FoodItemId { get; set; }
    }
}