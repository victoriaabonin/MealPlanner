using System;

namespace Api.ResponseModels;

public class IngredientOfRecipeResponseModel
{
    public IngredientResponseModel IngredientResponseModel { get; set; } = new IngredientResponseModel();

    public double Quantity { get; set; }
}
