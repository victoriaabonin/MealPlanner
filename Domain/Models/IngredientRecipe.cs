using Domain.Enums;

namespace Domain.Models;

public class IngredientRecipe
{
    public int IngredientId { get; set; }

    virtual public Ingredient Ingredient { get; set; }

    public int RecipeId { get; set; }

    virtual public Recipe Recipe { get; set; }

    public UnitOfMeasurement UnitOfMeasurement { get; set; }

    public double Quantity { get; set; }
}
