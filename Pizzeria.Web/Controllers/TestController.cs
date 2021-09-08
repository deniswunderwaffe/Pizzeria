using System;
using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Core.Dtos.PizzaDtos;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Models;
using Pizzeria.Core.Models.Drinks;

namespace Pizzeria.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        // private readonly IRepository<Pizza> _pizzaRepository;
        // private readonly IRepository<Drink> _drinkRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TestController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            //_pizzaRepository = pizzaRepository;
        }
        // GET
        [HttpGet]
        //[Authorize]
        public ActionResult<IEnumerable<PizzaReadDto>> GetAllPizza()
        {
            // _drinkRepository.Add(new AlcoholicDrink(){Brand = "Cvint",Concentration = 40,Name = "Divin"});
            // _pizzaRepository.Add(new Pizza(){Name = "Margarita",Price = 104,Type = "Italian"});
            // _drinkRepository.SaveAll();
            var pizzas = _unitOfWork.Pizzas.GetAll();
            var mappedResult = _mapper.Map<IEnumerable<PizzaReadDto>>(pizzas);
            return Ok(mappedResult);
        }
        [HttpGet("{id}",Name = "GetPizzaById")]
        public ActionResult<PizzaReadDto> GetPizzaById(int id)
        {
            var pizza = _unitOfWork.Pizzas.GetById(id);
            if (pizza is null)
            {
                return NotFound();
            }
            var mappedResult = _mapper.Map<PizzaReadDto>(pizza);
            return Ok(mappedResult);
        }

        [HttpPost]
        public ActionResult<PizzaReadDto> CreatePizza(PizzaCreateDto createDto)
        {
            //при добавлении существующих ингридиентов учитывает id созданной пиццы, что избавляет 
            //от необходимости передавать его через JSON 
            var pizzaModel = _mapper.Map<Pizza>(createDto);
            _unitOfWork.Pizzas.Add(pizzaModel);
            _unitOfWork.Complete();

            var readDto = _mapper.Map<PizzaReadDto>(pizzaModel);
            return CreatedAtRoute(nameof(GetPizzaById), new { Id = readDto.Id }, readDto);
        }
    }
} 