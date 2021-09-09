using System.Collections.Generic;
using Pizzeria.Core.Dtos.IngredientDtos;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Dtos.PizzaDtos
{
    public class PizzaReadDto:BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }

        public ICollection<IngredientReadDto> Ingredients { get; set; }
       
    }
}