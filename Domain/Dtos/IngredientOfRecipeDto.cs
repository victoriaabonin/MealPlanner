using Domain.Enums;

namespace Domain.Dtos;

public class IngredientOfRecipeDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public UnitOfMeasurement UnitOfMeasurement { get; set; }
    
    public double Quantity { get; set; }
}
