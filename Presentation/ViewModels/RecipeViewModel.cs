namespace Presentation.ViewModels;

public class RecipeViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<IngredientOfRecipeViewModel> IngredientsOfRecipesViewModels { get; set; }
}
