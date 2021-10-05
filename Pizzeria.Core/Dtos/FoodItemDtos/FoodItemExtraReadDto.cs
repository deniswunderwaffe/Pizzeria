namespace Pizzeria.Core.Dtos.FoodItemDtos
{
    public class FoodItemExtrasReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        //public string Description { get; set; }
        public int? FoodItemId { get; set; }
    }
}