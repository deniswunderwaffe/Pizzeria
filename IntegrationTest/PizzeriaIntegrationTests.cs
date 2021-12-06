using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Pizzeria.Core.Dtos.FoodItemDtos;
using Pizzeria.Core.Models;
using Pizzeria.Web;
using Xunit;

namespace IntegrationTest
{
    public class PizzeriaIntegrationTests: IClassFixture<ApplicationFactory<Startup>>
    {
        private readonly ApplicationFactory<Startup> _factory;

        public PizzeriaIntegrationTests(ApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }
        [Theory]
        [InlineData("/api/FoodItem")]
        [InlineData("/api/FoodItem/1")]
        public async Task GetVerb_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8", 
                response.Content.Headers.ContentType.ToString());
        }
        
        [Fact]
        public async Task PostVerb_UnauthorizedRequest_ReturnsUnauthorized()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.PostAsync("/api/FoodItem",new StringContent(""));

            // Assert
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
        [Fact]
        public async Task PostVerb_ReturnsCorrectType_WhenValidObjectReceived()
        {
            // Arrange
            var foodItem = new FoodItem() { Name = "qweqwe", Price = 123 };
            var client = _factory.CreateClient();

            // Act
            var response = await client.PostAsJsonAsync("/api/FoodItem",foodItem);

            using var result = response.Content.ReadFromJsonAsync<FoodItemReadDto>();

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.IsType<FoodItemReadDto>(result.Result);
        }
        [Fact]
        public async Task DeleteVerb_ReturnsNoContent_WhenValidIdProvided()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.DeleteAsync("/api/FoodItem/2");

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
        
        [Fact]
        public async Task DeleteVerb_ReturnsNotFound_WhenInvalidIdProvided()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.DeleteAsync("/api/FoodItem/500000");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        [Fact]
        public void PutVerb_ReturnsNoContent_WhenValidInputsProvided()
        {
            // Arrange
            var client = _factory.CreateClient();
            var foodItem = new FoodItemUpdateDto() { Name = "qweqwe",  Price = 123 };

            // Act
            var response = client.PutAsJsonAsync("/api/FoodItem/1", foodItem).Result;

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }
    }
}

