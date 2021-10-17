using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pizzeria.Core.Dtos.FoodItemDtos;
using Pizzeria.Core.HelperClasses;
using Pizzeria.Core.HelperClasses.Paging;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Models;

namespace Pizzeria.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodItemController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFoodItemService _service;

        public FoodItemController(IMapper mapper, IFoodItemService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FoodItemReadDto>> GetAllFood([FromQuery] FoodItemParameters foodItemParameters)
        {
            var allFood = _service.GetAllFoodPaged(foodItemParameters);
            var allFoodReadDto = _mapper.Map<IEnumerable<FoodItemReadDto>>(allFood);

            var metadata = new
            {
                allFood.TotalCount,
                allFood.PageSize,
                allFood.CurrentPage,
                allFood.TotalPages,
                allFood.HasNext,
                allFood.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(allFoodReadDto);
        }
        
        [HttpPost]
        [Route("recommendation")]
        public ActionResult<IEnumerable<FoodItemReadDto>> GetRecommendedFood(RecommendationModel recommendationModel)
        {
            var allFood = _service.GetRecommendedFood(recommendationModel);
            var allFoodReadDto = _mapper.Map<IEnumerable<FoodItemReadDto>>(allFood);
            
            return Ok(allFoodReadDto);
        }

        [HttpGet("{id}", Name = "GetFoodItemById")]
        public ActionResult<FoodItemReadDto> GetFoodItemById(int id)
        {
            var foodItem = _service.GetFoodItemById(id);
            if (foodItem is null) return NotFound();
            var foodItemReadDto = _mapper.Map<FoodItemReadDto>(foodItem);
            return Ok(foodItemReadDto);
        }

        [HttpPost]
        public ActionResult<FoodItemReadDto> CreateFoodItem(FoodItemCreateDto createDto)
        {
            var foodItemModel = _mapper.Map<FoodItem>(createDto);
            _service.AddFoodItem(foodItemModel);

            foodItemModel = _service.GetFoodItemById(foodItemModel.Id);

            var foodItemReadDto = _mapper.Map<FoodItemReadDto>(foodItemModel);
            return CreatedAtRoute(nameof(GetFoodItemById), new { foodItemReadDto.Id }, foodItemReadDto);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateFoodItem(int id, FoodItemUpdateDto updateDto)
        {
            var foodItemModel = _service.GetFoodItemById(id);
            if (foodItemModel is null) return NotFound();
            _mapper.Map(updateDto, foodItemModel);
            _service.UpdateFoodItem(foodItemModel);

            return NoContent();
        }

        [HttpPatch("{id}")]
        public ActionResult PatchFoodItem(int id, JsonPatchDocument<FoodItemUpdateDto> patchDoc)
        {
            var foodItemModel = _service.GetFoodItemById(id);
            if (foodItemModel is null) return NotFound();

            var foodItemToPatch = _mapper.Map<FoodItemUpdateDto>(foodItemModel);
            patchDoc.ApplyTo(foodItemToPatch, ModelState);

            if (!TryValidateModel(foodItemToPatch)) return ValidationProblem(ModelState);

            _mapper.Map(foodItemToPatch, foodItemModel);
            _service.UpdateFoodItem(foodItemModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteFoodItem(int id)
        {
            var foodItemModel = _service.GetFoodItemById(id);
            if (foodItemModel is null) return NotFound();
            _service.RemoveFoodItem(foodItemModel);
            return NoContent();
        }
    }
}