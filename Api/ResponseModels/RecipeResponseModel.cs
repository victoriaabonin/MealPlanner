using System;

namespace Api.ResponseModels;

public class RecipeResponseModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<IngredientOfRecipeResponseModel> IngredientsOfRecipesResponseModels { get; set; } = [];
}
