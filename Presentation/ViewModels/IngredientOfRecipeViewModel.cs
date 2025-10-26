namespace Presentation.ViewModels;

public class IngredientOfRecipeViewModel
{
    public IngredientViewModel IngredientViewModel { get; set; } = new IngredientViewModel();
    public double Quantity { get; set; }
}
