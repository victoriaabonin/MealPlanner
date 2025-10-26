using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Recipe
{
    [Required]
    public int Id { get; set; }

    [Required]
    [MinLength(1)]
    public string Name { get; set; } = string.Empty;

    public List<IngredientRecipe> IngredientRecipes { get; set; } = [];
}
