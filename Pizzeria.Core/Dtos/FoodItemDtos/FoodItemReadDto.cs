using Pizzeria.Core.Models;

namespace Pizzeria.Core.Dtos.FoodItemDtos
{
    public class FoodItemReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public FoodCategory FoodCategory { get; set; }
    }
}