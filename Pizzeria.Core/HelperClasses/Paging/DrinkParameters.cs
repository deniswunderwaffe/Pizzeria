namespace Pizzeria.Core.HelperClasses.Paging
{
    public class DrinkParameters:QueryStringParameters
    {
        public DrinkParameters()
        {
            OrderBy = "Id";
        }
        public string Brand { get; set; }
 
    }
}