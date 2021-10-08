namespace Pizzeria.Core.HelperClasses
{
    public class PromotionalCodeResponse
    {
        public int? Id { get; set; } = null;
        public bool IsValid { get; set; } = false;
        public decimal Discount { get; set; } = 0m;
        public string Name { get; set; } = "Error";
    }
}