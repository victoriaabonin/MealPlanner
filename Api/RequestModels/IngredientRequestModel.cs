using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Api.RequestModels;

public class IngredientRequestModel
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public UnitOfMeasurement UnitOfMeasurement { get; set; }
}
