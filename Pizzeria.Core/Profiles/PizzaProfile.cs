using AutoMapper;
using Pizzeria.Core.Dtos.PizzaDtos;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Profiles
{
    public class PizzaProfile:Profile
    {
        public PizzaProfile()
        {
            CreateMap<Pizza, PizzaReadDto>();
            CreateMap<PizzaCreateDto, Pizza>();
        }
    }
}