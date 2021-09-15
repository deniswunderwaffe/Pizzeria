using AutoMapper;
using Pizzeria.Core.Dtos.DrinkDtos;
using Pizzeria.Core.Models.Drinks;

namespace Pizzeria.Core.Profiles
{
    public class DrinkProfile:Profile
    {
        public DrinkProfile()
        {
            CreateMap<Drink, DrinkReadDto>()
                .Include<AlcoholicDrink,AlcoholicDrinkReadDto>()
                .Include<SodaDrink,SodaDrinkReadDto>();
            CreateMap<AlcoholicDrink, AlcoholicDrinkReadDto>();
            CreateMap<SodaDrink, SodaDrinkReadDto>();

            // CreateMap<DrinkCreateDto, Drink>()
            //     .Include<AlcoholicDrinkCreateDto, AlcoholicDrink>();
            CreateMap<AlcoholicDrinkCreateDto, AlcoholicDrink>();
        }
    }
}