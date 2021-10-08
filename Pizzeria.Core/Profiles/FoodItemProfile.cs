using Pizzeria.Core.Dtos.FoodItemDtos;
using Pizzeria.Core.Models;
using AutoMapper;

namespace Pizzeria.Core.Profiles
{
    public class FoodItemProfile : Profile
    {
        public FoodItemProfile()
        {
            CreateMap<FoodItem, FoodItemReadDto>();
            CreateMap<FoodItemCreateDto, FoodItem>();
            CreateMap<FoodItemUpdateDto, FoodItem>();
            CreateMap<FoodItem, FoodItemUpdateDto>();
        }
    }
}