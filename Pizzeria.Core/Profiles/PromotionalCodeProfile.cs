using AutoMapper;
using Pizzeria.Core.Dtos.PromotionalCodeDtos;
using Pizzeria.Core.Models;

namespace Pizzeria.Core.Profiles
{
    public class PromotionalCodeProfile:Profile
    {
        public PromotionalCodeProfile()
        {
            CreateMap<PromotionalCodeCreateDto, PromotionalCode>();
        }
    }
}