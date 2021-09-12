using System;
using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pizzeria.Core.Dtos.PizzaDtos;
using Pizzeria.Core.Exceptions;
using Pizzeria.Core.HelperClasses;
using Pizzeria.Core.HelperClasses.Paging;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Models;
using Pizzeria.Core.Models.Drinks;

namespace Pizzeria.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PizzaController : ControllerBase
    {
       // private readonly IUnitOfWork _unitOfWork;
        private readonly IPizzaService _pizzaService;
        private readonly IMapper _mapper;

        public PizzaController(/*IUnitOfWork unitOfWork*/ IMapper mapper, IPizzaService pizzaService)
        {
            //_unitOfWork = unitOfWork;
            _mapper = mapper;
            _pizzaService = pizzaService;
        }
        // GET
        [HttpGet]
        //[Authorize]
        public ActionResult<IEnumerable<PizzaReadDto>> GetAllPizza([FromQuery] PizzaParameters pizzaParameters)
        {
            if (!pizzaParameters.ValidPriceRange)
            {
                return BadRequest("Invalid price range");
            }
            var pizzas = _pizzaService.GetAllPizzasWithIngredients(pizzaParameters);
            var mappedResult = _mapper.Map<IEnumerable<PizzaReadDto>>(pizzas);
            var metadata = new
            {
                pizzas.TotalCount,
                pizzas.PageSize,
                pizzas.CurrentPage,
                pizzas.TotalPages,
                pizzas.HasNext,
                pizzas.HasPrevious
            };
            //Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(mappedResult);
        }
        [HttpGet("{id}",Name = "GetPizzaById")]
        public ActionResult<PizzaReadDto> GetPizzaById(int id)
        {
            var pizza = _pizzaService.GetPizzaById(id);
            if (pizza is null)
            {
                return NotFound();
            }
            var mappedResult = _mapper.Map<PizzaReadDto>(pizza);
            return Ok(mappedResult);
            //TODO нужно посмотреть про ViewModel и Generic Response
        }

        [HttpPost]
        [ApiExceptionFilter]
        public ActionResult<PizzaReadDto> CreatePizza(PizzaCreateDto createDto)
        {
            //при добавлении существующих ингридиентов учитывает id созданной пиццы, что избавляет 
            //от необходимости передавать его через JSON 
            var pizzaModel = _mapper.Map<Pizza>(createDto);
            _pizzaService.AddPizza(pizzaModel);
            
            var readDto = _mapper.Map<PizzaReadDto>(pizzaModel);
            return CreatedAtRoute(nameof(GetPizzaById), new { Id = readDto.Id }, readDto);
        }
        
        [HttpPut("{id}")]
        public ActionResult UpdatePizza(int id, PizzaUpdateDto updateDto)
        {
            var pizzaModel = _pizzaService.GetPizzaByIdWithIngredients(id);
            if (pizzaModel is null)
            {
                return NotFound();
            }
            pizzaModel.Ingredients.Clear(); //TODO Возможно есть более элегантный способ очистить коллекцию
            
            _mapper.Map(updateDto, pizzaModel);
            
            _pizzaService.UpdatePizza(pizzaModel);
            
            return NoContent();
        }
        [HttpPatch("{id}")]
        public ActionResult PatchPizza(int id, JsonPatchDocument<PizzaUpdateDto> patchDoc)
        {
            
            var pizzaModel = _pizzaService.GetPizzaByIdWithIngredients(id);
            if (pizzaModel is null)
            {
                return NotFound();
            }
           
            var pizzaToPatch = _mapper.Map<PizzaUpdateDto>(pizzaModel);
            patchDoc.ApplyTo(pizzaToPatch, ModelState);
            if(!TryValidateModel(pizzaToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(pizzaToPatch, pizzaModel);
            
            _pizzaService.UpdatePizza(pizzaModel);
            
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeletePizza(int id)
        {
            var pizzaModel = _pizzaService.GetPizzaById(id);
            if (pizzaModel is null)
            {
                return NotFound();
            }
           
            _pizzaService.RemovePizza(pizzaModel);

            return NoContent();
        }
    }
} 