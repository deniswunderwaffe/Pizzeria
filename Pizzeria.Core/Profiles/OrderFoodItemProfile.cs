using AutoMapper;
using Pizzeria.Core.Dtos.OrderDtos;
using Pizzeria.Core.Models.JoinTables;

namespace Pizzeria.Core.Profiles
{
    public class OrderFoodItemProfile : Profile
    {
        public OrderFoodItemProfile()
        {
            CreateMap<OrderFoodItem, OrderFoodItemReadDto>();
        }
    }
}