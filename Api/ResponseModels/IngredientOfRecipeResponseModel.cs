using System;
using Domain.Enums;

namespace Api.ResponseModels;

public class IngredientOfRecipeResponseModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public UnitOfMeasurement UnitOfMeasurement { get; set; }

    public double Quantity { get; set; }
}
