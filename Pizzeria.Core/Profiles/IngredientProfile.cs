using AutoMapper;
using Pizzeria.Core.Dtos.IngredientDtos;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Profiles
{
    public class IngredientProfile:Profile
    {
        public IngredientProfile()
        {
            CreateMap<Ingredient, IngredientReadDto>();
        }
    }
}