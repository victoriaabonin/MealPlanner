using Domain.Enums;

namespace Api.ResponseModels;

public class IngredientResponseModel
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
    
    public UnitOfMeasurement UnitOfMeasurement { get; set; }
}
