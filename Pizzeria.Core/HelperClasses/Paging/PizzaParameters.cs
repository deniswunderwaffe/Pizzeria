namespace Pizzeria.Core.HelperClasses.Paging
{
    public class PizzaParameters:QueryStringParameters
    {
        public PizzaParameters()
        {
            OrderBy = "Id";
        }
        public string Type { get; set; }
        public int? MinPrice { get; set; } = 1;
        public int? MaxPrice { get; set; } = 10000;
        public bool ValidPriceRange => MinPrice < MaxPrice;
    }
}