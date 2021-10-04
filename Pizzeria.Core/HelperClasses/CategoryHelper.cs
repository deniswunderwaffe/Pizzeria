using System.ComponentModel.DataAnnotations;

namespace Pizzeria.Core.HelperClasses
{
    public static class CategoryHelper
    {
        public enum FoodCategories
        {
            [Display(Name = "Pizza")]
            Pizza,
            [Display(Name = "Snack")]
            Snack,
            [Display(Name = "Drink")]
            Drink
        }
        
    }
}