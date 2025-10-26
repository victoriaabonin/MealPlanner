using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Models;

public class Ingredient
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MinLength(1)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public UnitOfMeasurement UnitOfMeasurement { get; set; }

    public List<IngredientRecipe> IngredientRecipes { get; set; } = [];
}
