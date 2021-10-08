using AutoMapper;
using Pizzeria.Core.Dtos.FoodItemDtos;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Profiles
{
    public class FoodItemExtraProfile : Profile
    {
        public FoodItemExtraProfile()
        {
            CreateMap<FoodItemExtra, FoodItemExtraReadDto>();
            CreateMap<FoodItemExtraCreateDto, FoodItemExtra>();
            CreateMap<FoodItemExtraUpdateDto, FoodItemExtra>();
            CreateMap<FoodItemExtra, FoodItemExtraUpdateDto>();
        }
    }
}