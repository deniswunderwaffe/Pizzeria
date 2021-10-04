namespace Pizzeria.Core.Dtos.FoodItemDtos
{
    public class FoodItemUpdateDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int FoodCategoryId { get; set; }
    }
}