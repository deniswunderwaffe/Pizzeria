using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
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
        

        public PizzaControllerTests()
        {
            _pizzaProfile = new PizzaProfile();
            _configuration = new MapperConfiguration(cfg => cfg.AddProfile(_pizzaProfile));
            _mapper = new Mapper(_configuration);
            _mockService = new Mock<IPizzaService>();
        }
        public void Dispose()
        {
            _pizzaProfile = null;
            _configuration = null;
            _mapper = null;
            _mockService = null;
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
        
        //GetAllPizzas------------------------------
        [Fact]
        public void GetAllPizza_Returns405BadRequest_WhenPizzaParametersInvalidPriceRange()
        {
            //Arrange 
            var pizzaParameters = new PizzaParameters()
            {
                MaxPrice = 50,
                MinPrice = 100
            };
            _mockService.Setup(repo =>
                repo.GetAllPizzasWithIngredients(It.Is<PizzaParameters>(x=> x == pizzaParameters)))
                .Returns(GetPizzas(1));

            
            
            var controller = new PizzaController(_mapper,_mockService.Object);

            //Act
            var result = controller.GetAllPizza(pizzaParameters);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);   
        }
        [Fact]
        public void GetAllPizza_Returns200OK_WhenDBIsEmpty()
        {
            //Arrange 
            var pizzaParameters = new PizzaParameters();
            _mockService.Setup(repo =>
                repo.GetAllPizzasWithIngredients(It.Is<PizzaParameters>(x=> x == pizzaParameters))).Returns(GetPizzas(0));

            var controller = new PizzaController(_mapper,_mockService.Object);

            //Act
            var result = controller.GetAllPizza(pizzaParameters);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);   
        }
        
        [Fact]
        public void GetAllPizza_Returns200OK_WhenDBHasOnePizza()
        {
            //Arrange 
            var pizzaParameters = new PizzaParameters();
            _mockService.Setup(repo =>
                repo.GetAllPizzasWithIngredients(It.Is<PizzaParameters>(x=> x == pizzaParameters))).Returns(GetPizzas(0));


            var controller = new PizzaController(_mapper,_mockService.Object);

            //Act
            var result = controller.GetAllPizza(pizzaParameters);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);   
        }
        [Fact]
        public void GetAllPizza_ReturnsCorrectType_WhenDBHasOnePizza()
        {
            //Arrange 
            var pizzaParameters = new PizzaParameters();
            _mockService.Setup(repo =>
                repo.GetAllPizzasWithIngredients(It.Is<PizzaParameters>(x=> x == pizzaParameters))).Returns(GetPizzas(0));


            var controller = new PizzaController(_mapper,_mockService.Object);

            //Act
            var result = controller.GetAllPizza(pizzaParameters);

            //Assert
            Assert.IsType<ActionResult<IEnumerable<PizzaReadDto>>>(result);   
        }
        

        //GetAllPizzaById------------------------------
        [Fact]
        public void GetPizzaById_Returns404NotFound_WhenNonExistentIdProvided()
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
        public void GetPizzaById_Returns200Ok_WhenValidIdProvided()
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
        public void GetPizzaById_ReturnsCorrectResourceType_WhenValidIdProvided()
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

        //CreatePizza
        [Fact]
        public void CreatePizza_ReturnsCorrectResourceType_WhenValidObjectSubmitted()
        {
            //Arrange 
            _mockService.Setup(repo =>
                repo.GetPizzaById(1)).Returns(() => new Pizza());
            var controller = new PizzaController(_mapper,_mockService.Object);

            //Act
            var result = controller.CreatePizza(new PizzaCreateDto());

            //Assert
            Assert.IsType<ActionResult<PizzaReadDto>>(result);
        }

        [Fact]
        public void CreatePizza_Returns201Created_WhenValidObjectSubmitted()
        {
            //Arrange 
            _mockService.Setup(repo =>
                repo.GetPizzaById(1)).Returns(() => new Pizza());
            var controller = new PizzaController(_mapper,_mockService.Object);

            //Act
            var result = controller.CreatePizza(new PizzaCreateDto());

            //Assert
            Assert.IsType<CreatedAtRouteResult>(result.Result);
        }
        
        //UpdatePizza------------------------------
        [Fact]
        public void UpdatePizza_Returns204NoContent_WhenValidObjectSubmitted()
        {
            //Arrange 
            _mockService.Setup(repo =>
                repo.GetPizzaByIdWithIngredients(1)).Returns(() => new Pizza()
            {
                Ingredients = new List<Ingredient>()
            });
            var controller = new PizzaController(_mapper,_mockService.Object);
            //Act
            var result = controller.UpdatePizza(1,new PizzaUpdateDto());
            //Assert
            Assert.IsType<NoContentResult>(result);
            
        }
        [Fact]
        public void UpdatePizza_Returns404NotFound_WhenObjectForUpdateNotExisting()
        {
            //Arrange 
            _mockService.Setup(repo =>
                repo.GetPizzaByIdWithIngredients(0)).Returns(() => null);
            var controller = new PizzaController(_mapper,_mockService.Object);
            //Act
            var result = controller.UpdatePizza(0,new PizzaUpdateDto());
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
        //PatchPizza----------------------------
        [Fact]
        public void PatchPizza_Returns404NotFound_WhenObjectForUpdateNotExisting()
        {
            //Arrange 
            _mockService.Setup(repo =>
                repo.GetPizzaByIdWithIngredients(0)).Returns(() => null);
            var controller = new PizzaController(_mapper,_mockService.Object);
            //Act
            var result = controller.PatchPizza(0,new JsonPatchDocument<PizzaUpdateDto>());
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
        //DeletePizza
        [Fact]
        public void DeletePizza_Returns204NoContent_WhenValidResourceIDSubmitted()
        {
            //Arrange
            _mockService.Setup(repo =>
                repo.GetPizzaById(1)).Returns(() => new Pizza());
            var controller = new PizzaController(_mapper,_mockService.Object);
            //Act
            var result = controller.DeletePizza(1);
            //Assert
            Assert.IsType<NoContentResult>(result);
        }
        [Fact]
        public void DeletePizza_Returns404NotFound_WhenObjectForUpdateNotExisting()
        {
            //Arrange
            _mockService.Setup(repo =>
                repo.GetPizzaById(1)).Returns(() => null);
            var controller = new PizzaController(_mapper,_mockService.Object);
            //Act
            var result = controller.DeletePizza(1);
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
        
    }
}