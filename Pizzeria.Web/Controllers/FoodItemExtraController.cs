using Microsoft.AspNetCore.Mvc;

namespace Pizzeria.Web.Controllers
{
    public class FoodItemExtraController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}