using System.ComponentModel.DataAnnotations;

namespace Pizzeria.Core.Dtos.FoodItemDtos
{
    public class FoodItemExtraCreateDto
    {
        [Required]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required] [Range(0.1, 99.99)] public decimal Price { get; set; }
        [StringLength(200)] public string Description { get; set; }
        public int? FoodItemId { get; set; }
    }
}