using System.ComponentModel.DataAnnotations;

namespace Pizzeria.Core.Dtos.DrinkDtos
{
    public class AlcoholicDrinkCreateDto:DrinkCreateDto
    {
        [Required]
        [Range(0,100)]
        public double Concentration { get; set; }
    }
}