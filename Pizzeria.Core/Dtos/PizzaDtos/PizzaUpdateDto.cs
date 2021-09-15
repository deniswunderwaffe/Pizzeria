using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Pizzeria.Core.Models.JoinTables;

namespace Pizzeria.Core.Dtos.PizzaDtos
{
    public class PizzaUpdateDto
    {
        [Required]
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        [Range(0, 1000)]
        public int Price { get; set; }
        
        public List<PizzaIngredient> PizzaIngredient { get; set; }
    }
}