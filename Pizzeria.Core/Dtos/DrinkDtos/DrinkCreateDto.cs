using System.ComponentModel.DataAnnotations;

namespace Pizzeria.Core.Dtos.DrinkDtos
{
    public class DrinkCreateDto
    {
        [Required]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Brand { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Name { get; set; }
    }
}