namespace Presentation.ViewModels;

public class RecipeViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<IngredientViewModel> Ingredients { get; set; }
}
