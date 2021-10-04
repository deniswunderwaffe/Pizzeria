using Pizzeria.Core.Models;

namespace Pizzeria.Core.HelperClasses.Paging
{
    public class FoodItemParameters:QueryStringParameters
    {
        public FoodItemParameters()
        {
            OrderBy = "Id";
        }
        public string Category { get; set; }
        public int? MinPrice { get; set; } = 1;
        public int? MaxPrice { get; set; } = 100;
        public bool ValidPriceRange => MinPrice < MaxPrice;
    }
}