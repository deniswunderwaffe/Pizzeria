using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Pizzeria.Core.Models;
using Pizzeria.Core.Models.JoinTables;

namespace Pizzeria.Core.Dtos.PizzaDtos
{
    public class PizzaCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public int Price { get; set; }

        public List<PizzaIngredient> PizzaIngredient { get; set; }
    }
}