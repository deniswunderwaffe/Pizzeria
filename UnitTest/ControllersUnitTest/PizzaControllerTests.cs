using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Pizzeria.Core.Dtos.PizzaDtos;
using Pizzeria.Core.HelperClasses.Paging;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Interfaces.Specific;
using Pizzeria.Core.Models;
using Pizzeria.Core.Profiles;
using Pizzeria.Web.Controllers;
using Xunit;

namespace UnitTest.ControllersUnitTest
{
    public class PizzaControllerTests:IDisposable
    {
        Mock<IPizzaService> _mockService;
        PizzaProfile _pizzaProfile;
        MapperConfiguration _configuration;
        IMapper _mapper;
        PizzaParameters _pizzaParameters;

        public PizzaControllerTests()
        {
            _pizzaProfile = new PizzaProfile();
            _configuration = new MapperConfiguration(cfg => cfg.AddProfile(_pizzaProfile));
            _mapper = new Mapper(_configuration);
            _mockService = new Mock<IPizzaService>();
            _pizzaParameters = new PizzaParameters();
        }
        public void Dispose()
        {
            _pizzaProfile = null;
            _configuration = null;
            _mapper = null;
            _mockService = null;
            _pizzaParameters = null;
        }
        private PagedList<Pizza> GetPizzas(int num)
        {
            var pizzas = new List<Pizza>();
            if (num > 0)
            {
                pizzas.Add(new Pizza
                {
                    Id = 0,
                    Name = "qwe",
                    Type = "American",
                    Price = 100
                });
            }
            var result = new PagedList<Pizza>(pizzas, 1, 1, 1);
            return result;
        }
        [Fact]
        public void GetPizzas_ReturnsZeroItems_WhenDBIsEmpty()
        {
            //Arrange 
            _mockService.Setup(repo =>
                repo.GetAllPizzasWithIngredients(_pizzaParameters)).Returns(GetPizzas(0));

            var controller = new PizzaController(_mapper,_mockService.Object);

            //Act
            var result = controller.GetAllPizza(_pizzaParameters);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);   
        }

        [Fact]
        public void GetCommandByID_Returns404NotFound_WhenNonExistentIDProvided()
        {
            //Arrange 
            _mockService.Setup(repo =>
                repo.GetPizzaById(0)).Returns(() => null);

            var controller = new PizzaController(_mapper,_mockService.Object);
            //Act
            var result = controller.GetPizzaById(0);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
        [Fact]
        public void GetCommandByID_Returns200Ok_WhenValidIdProvided()
        {
            //Arrange 
            _mockService.Setup(repo =>
                repo.GetPizzaById(1)).Returns(() => new Pizza());

            var controller = new PizzaController(_mapper,_mockService.Object);
            //Act
            var result = controller.GetPizzaById(1);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }
        [Fact]
        public void GetCommandByID_ReturnsCorrectResouceType_WhenValidIDProvided()
        {
            //Arrange 
            _mockService.Setup(repo =>
                repo.GetPizzaById(1)).Returns(() => new Pizza());

            var controller = new PizzaController(_mapper,_mockService.Object);

            //Act
            var result = controller.GetPizzaById(1);

            //Assert
            Assert.IsType<ActionResult<PizzaReadDto>>(result);
        }

        
    }
}