using AutoMapper;
using Pizzeria.Core.Dtos.OrderDtos;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Profiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderReadDto>();
            CreateMap<OrderCreateDto, Order>();
            CreateMap<OrderUpdateDto, Order>();
            CreateMap<Order, OrderUpdateDto>();
        }
    }
}