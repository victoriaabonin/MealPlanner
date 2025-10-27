using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Api.RequestModels;

public class IngredientRequestModel
{
    [Required]
    public string Name { get; set; } = string.Empty;
    public UnitOfMeasurement UnitOfMeasurement { get; set; }
}
