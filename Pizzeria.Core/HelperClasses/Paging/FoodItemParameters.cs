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
        public decimal? MinPrice { get; set; } = 0.10m;
        public decimal? MaxPrice { get; set; } = 999.99m;
        public bool ValidPriceRange => MinPrice < MaxPrice;
    }
}