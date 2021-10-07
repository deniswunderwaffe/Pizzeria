using Microsoft.AspNetCore.Mvc;

namespace Pizzeria.Core.Services
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error() => Problem();
    }
}