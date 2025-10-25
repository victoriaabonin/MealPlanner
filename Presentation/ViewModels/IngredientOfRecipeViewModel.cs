using Domain.Enums;

namespace Presentation.ViewModels;

public class IngredientOfRecipeViewModel
{
    public IngredientViewModel IngredientViewModel { get; set; }
    public UnitOfMeasurement UnitOfMeasurement { get; set; }
    public double Quantity { get; set; }
}
