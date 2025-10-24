namespace Domain.Models;

public class Ingredient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<IngredientRecipe> IngredientRecipes { get; set; }
}
