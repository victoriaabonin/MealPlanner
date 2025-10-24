using Domain.Models;

namespace Infrastructure;

public static class TempDataBase
{
    public static List<Ingredient> Ingredients { get; set; }
    public static List<Recipe> Recipes { get; set; }
    public static List<IngredientRecipe> IngredientRecipes { get; set; }
}
