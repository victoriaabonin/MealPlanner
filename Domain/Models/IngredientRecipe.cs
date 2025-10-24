using Domain.Enums;

namespace Domain.Models;

public class IngredientRecipe
{
    public int IngredientId { get; set; }
    public int RecipeId { get; set; }
    public UnitOfMeasurement UnitOfMeasurement { get; set; }
    public double Quantity { get; set; }
}
