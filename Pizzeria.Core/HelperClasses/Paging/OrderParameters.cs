namespace Pizzeria.Core.HelperClasses.Paging
{
    public class OrderParameters : QueryStringParameters
    {
        public OrderParameters()
        {
            OrderBy = "Id";
        }
        public decimal? MinPrice { get; set; } = 0.10m;
        public decimal? MaxPrice { get; set; } = 9999.99m;
        public bool ValidPriceRange => MinPrice < MaxPrice;
    }
}
