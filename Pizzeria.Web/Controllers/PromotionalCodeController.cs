using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Core.Dtos.OrderDtos;
using Pizzeria.Core.Dtos.PromotionalCodeDtos;
using Pizzeria.Core.HelperClasses;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Models;

namespace Pizzeria.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromotionalCodeController : ControllerBase
    {
        private readonly IPromotionalCodeService _promotionalCodeService;
        private readonly IMapper _mapper;

        public PromotionalCodeController(IPromotionalCodeService promotionalCodeService, IMapper mapper)
        {
            _promotionalCodeService = promotionalCodeService;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetPromotionalCodeById")]
        public ActionResult<PromotionalCodeReadDto> GetPromotionalCodeById(int id)
        {
            var promotionalCode = _promotionalCodeService.GetPromotionalCodeById(id);
            if (promotionalCode is null) return NotFound();

            var promotionalCodeReadDto = _mapper.Map<PromotionalCodeReadDto>(promotionalCode);
            return Ok(promotionalCodeReadDto);
        }

        [HttpPost]
        public ActionResult CreateCode(PromotionalCodeCreateDto createDto)
        {
            var codeModel = _mapper.Map<PromotionalCode>(createDto);
            _promotionalCodeService.AddPromotionalCode(codeModel);

            var promotionalCodeReadDto = _mapper.Map<PromotionalCodeReadDto>(codeModel);
            return CreatedAtRoute(nameof(GetPromotionalCodeById), new { Id = promotionalCodeReadDto.Id },
                promotionalCodeReadDto);
        }

        [HttpPost]
        [Route("validate")]
        public ActionResult<PromotionalCodeResponse> CreateFoodItem(string promotionalCode)
        {
            var response = _promotionalCodeService.ValidateCode(promotionalCode);
            return Ok(response);
        }
    }
}