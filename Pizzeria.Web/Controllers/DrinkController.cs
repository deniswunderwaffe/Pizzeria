using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Core.Dtos.DrinkDtos;
using Pizzeria.Core.HelperClasses.Paging;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Models.Drinks;

namespace Pizzeria.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrinkController:ControllerBase
    {
        private readonly IDrinkService _drinkService;
        private readonly IMapper _mapper;

        public DrinkController(IDrinkService drinkService, IMapper mapper)
        {
            _drinkService = drinkService;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult<DrinkReadDto> GetAllDrinks([FromQuery] DrinkParameters drinkParameters)
        {
            var orders = _drinkService.GetAllDrinks(drinkParameters);
            var mappedResult = _mapper.Map<IEnumerable<DrinkReadDto>>(orders);

            return Ok(mappedResult);
        }
        [HttpGet("{id}",Name = "GetDrinkById")]
        public ActionResult<DrinkReadDto> GetDrinkById(int id)
        {
            var drink = _drinkService.GetDrinkById(id);
            if (drink is null)
            {
                return NotFound();
            }
            var mappedResult = _mapper.Map<DrinkReadDto>(drink);
            return Ok(mappedResult);
        }
        [HttpPost("/api/[controller]/[action]")]
        public ActionResult<AlcoholicDrinkReadDto> CreateAlcoholicDrink(AlcoholicDrinkCreateDto createDto)
        {
            //TODO как должно быть?
            var drinkModel = _mapper.Map<AlcoholicDrink>(createDto);
            _drinkService.AddDrink(drinkModel);
            
            var readDto = _mapper.Map<AlcoholicDrinkReadDto>(drinkModel);
            return CreatedAtRoute(nameof(GetDrinkById), new { Id = readDto.Id }, readDto);
        }
        [HttpPost("/api/[controller]/[action]")]
        public ActionResult<SodaDrinkReadDto> CreateSodaDrink(SodaDrinkCreateDto createDto)
        {
            var drinkModel = _mapper.Map<SodaDrink>(createDto);
            _drinkService.AddDrink(drinkModel);
            
            var readDto = _mapper.Map<SodaDrinkReadDto>(drinkModel);
            return CreatedAtRoute(nameof(GetDrinkById), new { Id = readDto.Id }, readDto);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteDrink(int id)
        {
            var drinkModel = _drinkService.GetDrinkById(id);
            if (drinkModel is null)
            {
                return NotFound();
            }
            _drinkService.RemoveDrink(drinkModel);

            return NoContent();
        }
        
    }
}