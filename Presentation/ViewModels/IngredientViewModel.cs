using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Presentation.ViewModels;

public class IngredientViewModel
{
    public int Id { get; set; }

    [RegularExpression(@"^.+\S.*$", ErrorMessage = "Code cannot be empty or whitespace")]
    public string Name { get; set; } = string.Empty;

    public UnitOfMeasurement UnitOfMeasurement { get; set; }

    public List<RecipeViewModel> Recipes { get; set; } = [];
}
