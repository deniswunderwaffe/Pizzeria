using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pizzeria.Core.Dtos.FoodItemDtos;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Models;

namespace Pizzeria.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodItemExtraController : ControllerBase
    {
        private readonly IFoodItemExtraService _service;
        private readonly IMapper _mapper;

        public FoodItemExtraController(IMapper mapper, IFoodItemExtraService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FoodItemExtraReadDto>> GetExtrasForFoodItem([FromQuery] int foodItemId)
        {
            var extrasForFoodItem = _service.GetExtrasForFoodItem(foodItemId);
            var extrasForFoodItemDto = _mapper.Map<IEnumerable<FoodItemExtraReadDto>>(extrasForFoodItem);

            return Ok(extrasForFoodItemDto);
        }

        [HttpGet("{id}", Name = "GetFoodItemExtraById")]
        public ActionResult<FoodItemExtraReadDto> GetFoodItemExtraById(int id)
        {
            var foodItemExtra = _service.GetFoodItemExtraById(id);
            if (foodItemExtra is null) return NotFound();

            var foodItemExtraReadDto = _mapper.Map<FoodItemExtraReadDto>(foodItemExtra);
            return Ok(foodItemExtraReadDto);
        }

        [HttpPost]
        public ActionResult CreateFoodItemExtra(FoodItemExtraCreateDto createDto)
        {
            var foodItemExtraModel = _mapper.Map<FoodItemExtra>(createDto);
            _service.AddFoodItemExtra(foodItemExtraModel);

            var foodItemExtraReadDto = _mapper.Map<FoodItemExtraReadDto>(foodItemExtraModel);
            return CreatedAtRoute(nameof(GetFoodItemExtraById), new { Id = foodItemExtraReadDto.Id },
                foodItemExtraReadDto);
        }

        [HttpPatch("{id}")]
        public ActionResult PatchFoodItemExtra(int id, JsonPatchDocument<FoodItemExtraUpdateDto> patchDoc)
        {
            var foodItemExtraModel = _service.GetFoodItemExtraById(id);
            if (foodItemExtraModel is null) return NotFound();

            var foodItemExtraToPatch = _mapper.Map<FoodItemExtraUpdateDto>(foodItemExtraModel);
            patchDoc.ApplyTo(foodItemExtraToPatch, ModelState);

            if (!TryValidateModel(foodItemExtraToPatch)) return ValidationProblem(ModelState);

            _mapper.Map(foodItemExtraToPatch, foodItemExtraModel);
            _service.UpdateFoodItemExtra(foodItemExtraModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteFoodItemExtra(int id)
        {
            var foodItemExtraModel = _service.GetFoodItemExtraById(id);
            if (foodItemExtraModel is null) return NotFound();
            _service.RemoveFoodItemExtra(foodItemExtraModel);
            return NoContent();
        }
    }
}