using System;

namespace Api.RequestModels;

public class RemoveIngredientFromRecipeRequestModel
{
    public int RecipeId { get; set; }
    public int IngredientId { get; set; }
}
