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
    public class PromotionalCodeController:ControllerBase
    {
        private readonly IPromotionalCodeService _promotionalCodeService;
        private readonly IMapper _mapper;

        public PromotionalCodeController(IPromotionalCodeService promotionalCodeService, IMapper mapper)
        {
            _promotionalCodeService = promotionalCodeService;
            _mapper = mapper;
        }
        [HttpPost]
        public ActionResult CreateCode(PromotionalCodeCreateDto createDto)
        {
            var codeModel = _mapper.Map<PromotionalCode>(createDto);
            _promotionalCodeService.AddPromotionalCode(codeModel);
            return Ok();
            //TODO по человечески доделать
            // return CreatedAtRoute("nameof(GetOrderById)", new { Id = codeModel.Id }, codeModel);
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