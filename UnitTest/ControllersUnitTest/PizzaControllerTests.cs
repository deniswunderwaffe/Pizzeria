using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Pizzeria.Core.Dtos.FoodItemDtos;
using Pizzeria.Core.HelperClasses.Paging;
using Pizzeria.Core.Interfaces;
using Pizzeria.Core.Interfaces.Specific;
using Pizzeria.Core.Models;
using Pizzeria.Core.Profiles;
using Pizzeria.Web.Controllers;
using Xunit;

namespace UnitTest.ControllersUnitTest
{
    public class FoodItemControllerTests:IDisposable
    {
        Mock<IFoodItemService> _mockService;
        FoodItemProfile _foodItemProfile;
        MapperConfiguration _configuration;
        IMapper _mapper;
        

        public FoodItemControllerTests()
        {
            _foodItemProfile = new FoodItemProfile();
            _configuration = new MapperConfiguration(cfg => cfg.AddProfile(_foodItemProfile));
            _mapper = new Mapper(_configuration);
            _mockService = new Mock<IFoodItemService>();
        }
        public void Dispose()
        {
            _foodItemProfile = null;
            _configuration = null;
            _mapper = null;
            _mockService = null;
        }
        private PagedList<FoodItem> GetFoodItems(int num)
        {
            var foodItems = new List<FoodItem>();
            if (num > 0)
            {
                foodItems.Add(new FoodItem
                {
                    Id = 0,
                    Name = "qwe",
                    
                    Price = 100
                });
            }
            var result = new PagedList<FoodItem>(foodItems, 1, 1, 1);
            return result;
        }
        
        [Fact]
        public void GetAllFoodItem_Returns405BadRequest_WhenFoodItemParametersInvalidPriceRange()
        {
            //Arrange 
            var FoodItemParameters = new FoodItemParameters()
            {
                MaxPrice = 50,
                MinPrice = 100
            };
            _mockService.Setup(repo =>
                repo.GetAllFoodPaged(It.Is<FoodItemParameters>(x=> x == FoodItemParameters)))
                .Returns(GetFoodItems(1));

            
            
            var controller = new FoodItemController(_mapper,_mockService.Object);

            //Act
            var result = controller.GetAllFood(FoodItemParameters);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);   
        }
        [Fact]
        public void GetAllFoodItem_Returns200OK_WhenDBIsEmpty()
        {
            //Arrange 
            var FoodItemParameters = new FoodItemParameters();
            _mockService.Setup(repo =>
                repo.GetAllFoodPaged(It.Is<FoodItemParameters>(x=> x == FoodItemParameters))).Returns(GetFoodItems(0));

            var controller = new FoodItemController(_mapper,_mockService.Object);

            //Act
            var result = controller.GetAllFood(FoodItemParameters);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);   
        }
        
        [Fact]
        public void GetAllFoodItem_Returns200OK_WhenDBHasOneFoodItem()
        {
            //Arrange 
            var FoodItemParameters = new FoodItemParameters();
            _mockService.Setup(repo =>
                repo.GetAllFoodPaged(It.Is<FoodItemParameters>(x=> x == FoodItemParameters))).Returns(GetFoodItems(0));


            var controller = new FoodItemController(_mapper,_mockService.Object);

            //Act
            var result = controller.GetAllFood(FoodItemParameters);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);   
        }
        [Fact]
        public void GetAllFoodItem_ReturnsCorrectType_WhenDBHasOneFoodItem()
        {
            //Arrange 
            var FoodItemParameters = new FoodItemParameters();
            _mockService.Setup(repo =>
                repo.GetAllFoodPaged(It.Is<FoodItemParameters>(x=> x == FoodItemParameters))).Returns(GetFoodItems(0));


            var controller = new FoodItemController(_mapper,_mockService.Object);

            //Act
            var result = controller.GetAllFood(FoodItemParameters);

            //Assert
            Assert.IsType<ActionResult<IEnumerable<FoodItemReadDto>>>(result);   
        }
        

        //GetAllFoodItemById------------------------------
        [Fact]
        public void GetFoodItemById_Returns404NotFound_WhenNonExistentIdProvided()
        {
            //Arrange 
            _mockService.Setup(repo =>
                repo.GetFoodItemById(0)).Returns(() => null);

            var controller = new FoodItemController(_mapper,_mockService.Object);
            //Act
            var result = controller.GetFoodItemById(0);

            //Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
        [Fact]
        public void GetFoodItemById_Returns200Ok_WhenValidIdProvided()
        {
            //Arrange 
            _mockService.Setup(repo =>
                repo.GetFoodItemById(1)).Returns(() => new FoodItem());

            var controller = new FoodItemController(_mapper,_mockService.Object);
            //Act
            var result = controller.GetFoodItemById(1);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }
        [Fact]
        public void GetFoodItemById_ReturnsCorrectResourceType_WhenValidIdProvided()
        {
            //Arrange 
            _mockService.Setup(repo =>
                repo.GetFoodItemById(1)).Returns(() => new FoodItem());

            var controller = new FoodItemController(_mapper,_mockService.Object);

            //Act
            var result = controller.GetFoodItemById(1);

            //Assert
            Assert.IsType<ActionResult<FoodItemReadDto>>(result);
        }

        //CreateFoodItem
        [Fact]
        public void CreateFoodItem_ReturnsCorrectResourceType_WhenValidObjectSubmitted()
        {
            //Arrange 
            _mockService.Setup(repo =>
                repo.GetFoodItemById(1)).Returns(() => new FoodItem());
            var controller = new FoodItemController(_mapper,_mockService.Object);

            //Act
            var result = controller.CreateFoodItem(new FoodItemCreateDto());

            //Assert
            Assert.IsType<ActionResult<FoodItemReadDto>>(result);
        }

        [Fact]
        public void CreateFoodItem_Returns201Created_WhenValidObjectSubmitted()
        {
            //Arrange 
            _mockService.Setup(repo =>
                repo.GetFoodItemById(1)).Returns(() => new FoodItem());
            var controller = new FoodItemController(_mapper,_mockService.Object);

            //Act
            var result = controller.CreateFoodItem(new FoodItemCreateDto());

            //Assert
            Assert.IsType<CreatedAtRouteResult>(result.Result);
        }
        
        //UpdateFoodItem------------------------------
        [Fact]
        public void UpdateFoodItem_Returns204NoContent_WhenValidObjectSubmitted()
        {
            //Arrange 
            _mockService.Setup(repo =>
                repo.GetFoodItemById(1)).Returns(() => new FoodItem()
            {
               
            });
            var controller = new FoodItemController(_mapper,_mockService.Object);
            //Act
            var result = controller.UpdateFoodItem(1,new FoodItemUpdateDto());
            //Assert
            Assert.IsType<NoContentResult>(result);
            
        }
        [Fact]
        public void UpdateFoodItem_Returns404NotFound_WhenObjectForUpdateNotExisting()
        {
            //Arrange 
            _mockService.Setup(repo =>
                repo.GetFoodItemById(0)).Returns(() => null);
            var controller = new FoodItemController(_mapper,_mockService.Object);
            //Act
            var result = controller.UpdateFoodItem(0,new FoodItemUpdateDto());
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
        //PatchFoodItem----------------------------
        [Fact]
        public void PatchFoodItem_Returns404NotFound_WhenObjectForUpdateNotExisting()
        {
            //Arrange 
            _mockService.Setup(repo =>
                repo.GetFoodItemById(0)).Returns(() => null);
            var controller = new FoodItemController(_mapper,_mockService.Object);
            //Act
            var result = controller.PatchFoodItem(0,new JsonPatchDocument<FoodItemUpdateDto>());
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
        //DeleteFoodItem
        [Fact]
        public void DeleteFoodItem_Returns204NoContent_WhenValidResourceIDSubmitted()
        {
            //Arrange
            _mockService.Setup(repo =>
                repo.GetFoodItemById(1)).Returns(() => new FoodItem());
            var controller = new FoodItemController(_mapper,_mockService.Object);
            //Act
            var result = controller.DeleteFoodItem(1);
            //Assert
            Assert.IsType<NoContentResult>(result);
        }
        [Fact]
        public void DeleteFoodItem_Returns404NotFound_WhenObjectForUpdateNotExisting()
        {
            //Arrange
            _mockService.Setup(repo =>
                repo.GetFoodItemById(1)).Returns(() => null);
            var controller = new FoodItemController(_mapper,_mockService.Object);
            //Act
            var result = controller.DeleteFoodItem(1);
            //Assert
            Assert.IsType<NotFoundResult>(result);
        }
        
    }
}

