namespace Pizzeria.Core.Models.JoinTables
{
    public class PizzaIngredient
    {
        
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}