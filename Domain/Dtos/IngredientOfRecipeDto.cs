using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos;

public class IngredientOfRecipeDto
{
    public IngredientDto IngredientDto { get; set; } = new IngredientDto();

    public double Quantity { get; set; }
}
