namespace Presentation.ViewModels;

public class IngredientViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<RecipeViewModel> Recipes { get; set; }
}
