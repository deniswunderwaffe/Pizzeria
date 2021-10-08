// using System.Net;
// using System.Net.Http;
// using System.Net.Http.Json;
// using System.Text.Json;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Testing;
// using Pizzeria.Core.Dtos.PizzaDtos;
// using Pizzeria.Web;
// using Xunit;
//
// namespace IntegrationTest
// {
//     public class PizzeriaIntegrationTests: IClassFixture<ApplicationFactory<Startup>>
//     {
//         private readonly ApplicationFactory<Startup> _factory;
//
//         public PizzeriaIntegrationTests(ApplicationFactory<Startup> factory)
//         {
//             _factory = factory;
//         }
//         [Theory]
//         [InlineData("/api/Pizza")]
//         [InlineData("/api/Pizza/1")]
//         public async Task GetVerb_EndpointsReturnSuccessAndCorrectContentType(string url)
//         {
//             // Arrange
//             var client = _factory.CreateClient();
//
//             // Act
//             var response = await client.GetAsync(url);
//
//             // Assert
//             response.EnsureSuccessStatusCode(); // Status Code 200-299
//             Assert.Equal("application/json; charset=utf-8", 
//                 response.Content.Headers.ContentType.ToString());
//         }
//         
//         [Fact]
//         public async Task PostVerb_UnauthorizedRequest_ReturnsUnauthorized()
//         {
//             // Arrange
//             var client = _factory.CreateClient();
//
//             // Act
//             var response = await client.PostAsync("/api/Pizza",new StringContent(""));
//
//             // Assert
//             Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
//         }
//         [Fact]
//         public async Task PostVerb_ReturnsCorrectType_WhenValidObjectReceived()
//         {
//             // Arrange
//             var pizza = new PizzaUpdateDto() { Name = "qweqwe", Type = "American", Price = 123 };
//             var client = _factory.CreateClient();
//
//             // Act
//             var response = await client.PostAsJsonAsync("/api/Pizza",pizza);
//
//             using var result = response.Content.ReadFromJsonAsync<PizzaReadDto>();
//
//             // Assert
//             Assert.Equal(HttpStatusCode.Created, response.StatusCode);
//             Assert.IsType<PizzaReadDto>(result.Result);
//         }
//         [Fact]
//         public async Task DeleteVerb_ReturnsNoContent_WhenValidIdProvided()
//         {
//             // Arrange
//             var client = _factory.CreateClient();
//
//             // Act
//             var response = await client.DeleteAsync("/api/Pizza/2");
//
//             // Assert
//             Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
//         }
//         //TODO нужен?
//         [Fact]
//         public async Task DeleteVerb_ReturnsNotFound_WhenInvalidIdProvided()
//         {
//             // Arrange
//             var client = _factory.CreateClient();
//
//             // Act
//             var response = await client.DeleteAsync("/api/Pizza/500000");
//
//             // Assert
//             Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
//         }
//         [Fact]
//         public void PutVerb_ReturnsNoContent_WhenValidInputsProvided()
//         {
//             // Arrange
//             var client = _factory.CreateClient();
//             var pizza = new PizzaUpdateDto() { Name = "qweqwe", Type = "American", Price = 123 };
//
//             // Act
//             var response = client.PutAsJsonAsync("/api/Pizza/1", pizza).Result;
//
//             // Assert
//             Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
//         }
//     }
// }

