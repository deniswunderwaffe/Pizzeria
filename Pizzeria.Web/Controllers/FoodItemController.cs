using System;
using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pizzeria.Core.Dtos.FoodItemDtos;
using Pizzeria.Core.HelperClasses;
using Pizzeria.Core.HelperClasses.Paging;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Interfaces.Specific;
using Pizzeria.Core.Models;


namespace Pizzeria.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodItemController : ControllerBase
    {
     
        private readonly IFoodItemService _service;
        private readonly IMapper _mapper;

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
        
        [HttpGet("{id}",Name = "GetFoodItemById")]
        public ActionResult<FoodItemReadDto> GetFoodItemById(int id)
        {
            var foodItem = _service.GetFoodItemById(id);
            if (foodItem is null)
            {
                return NotFound();
            }
            var foodItemReadDto = _mapper.Map<FoodItemReadDto>(foodItem);
            return Ok(foodItemReadDto);
        }
        
        [HttpPost]
        public ActionResult<FoodItemReadDto> CreateFoodItem(FoodItemCreateDto createDto)
        {
            var foodItemModel = _mapper.Map<FoodItem>(createDto);
            _service.AddFoodItem(foodItemModel);

            //TODO на случай если нужно вернуть полный обьект
            //foodItemModel = _service.GetFoodItemById(foodItemModel.Id);
            
            var foodItemReadDto = _mapper.Map<FoodItemReadDto>(foodItemModel);
            return CreatedAtRoute(nameof(GetFoodItemById), new { Id = foodItemReadDto.Id }, foodItemReadDto);
        }
        
        [HttpPut("{id}")]
        public ActionResult UpdateFoodItem(int id, FoodItemUpdateDto updateDto)
        {
            var foodItemModel = _service.GetFoodItemById(id);
            if (foodItemModel is null)
            {
                return NotFound();
            }
            _mapper.Map(updateDto, foodItemModel);
            _service.UpdateFoodItem(foodItemModel);
            
            return NoContent();
        }
        
        [HttpPatch("{id}")]
        public ActionResult PatchFoodItem(int id, JsonPatchDocument<FoodItemUpdateDto> patchDoc)
        {
            var foodItemModel = _service.GetFoodItemById(id);
            if (foodItemModel is null)
            {
                return NotFound();
            }
            
            var foodItemToPatch = _mapper.Map<FoodItemUpdateDto>(foodItemModel);
            patchDoc.ApplyTo(foodItemToPatch, ModelState);
            
            if(!TryValidateModel(foodItemToPatch))
            {
                return ValidationProblem(ModelState);
            }
            
            _mapper.Map(foodItemToPatch, foodItemModel);
            _service.UpdateFoodItem(foodItemModel);
            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public ActionResult DeleteFoodItem(int id)
        {
            var foodItemModel = _service.GetFoodItemById(id);
            if (foodItemModel is null)
            {
                return NotFound();
            }
            _service.RemoveFoodItem(foodItemModel);
            return NoContent();
        }

        // [HttpGet]
        // //[Authorize]
        // public ActionResult<IEnumerable<PizzaReadDto>> GetAllPizza([FromQuery] PizzaParameters pizzaParameters)
        // {
        //     if (!pizzaParameters.ValidPriceRange)
        //     {
        //         return BadRequest("Invalid price range");
        //     }
        //     var pizzas = _pizzaService.GetAllPizzasWithIngredients(pizzaParameters);
        //     var mappedResult = _mapper.Map<IEnumerable<PizzaReadDto>>(pizzas);
        //     var metadata = new
        //     {
        //         pizzas.TotalCount,
        //         pizzas.PageSize,
        //         pizzas.CurrentPage,
        //         pizzas.TotalPages,
        //         pizzas.HasNext,
        //         pizzas.HasPrevious
        //     };
        //     //Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
        //     return Ok(mappedResult);
        // }
    }
} 