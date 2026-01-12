namespace RestaurantAppMVC.Models
{
    public class Ingredient
    {
        public int IngredientId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<ProductIngredient> ProductIngredients { get; set; } = new List<ProductIngredient>();

    }
}