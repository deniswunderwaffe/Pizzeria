using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public TestController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_pizzaRepository = pizzaRepository;
        }
        // GET
        [HttpGet]
        public IActionResult Index()
        {
            // _drinkRepository.Add(new AlcoholicDrink(){Brand = "Cvint",Concentration = 40,Name = "Divin"});
            // _pizzaRepository.Add(new Pizza(){Name = "Margarita",Price = 104,Type = "Italian"});
            // _drinkRepository.SaveAll();
            _unitOfWork.Pizzas.Add(new Pizza(){Name = "Margarita",Price = 104,Type = "Italian"});
            _unitOfWork.Complete();
            return Ok(_unitOfWork.Pizzas.GetAllPizzasByType("American"));
        }
    }
}