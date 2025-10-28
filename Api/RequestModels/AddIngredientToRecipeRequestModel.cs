using System;

namespace Api.RequestModels;

public class AddIngredientToRecipeRequestModel
{
    public int RecipeId { get; set; }

    public int IngredientId { get; set; }
    
    public double Quantity { get; set; }
}
