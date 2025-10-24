using System;
using Domain.Enums;

namespace Domain.Dtos;

public class IngredientOfRecipeDto
{
    public IngredientDto IngredientDto { get; set; }
    public UnitOfMeasurement UnitOfMeasurement { get; set; }
    public int Quantity { get; set; }
}
