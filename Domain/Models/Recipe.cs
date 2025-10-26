using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Recipe
{
    [Required]
    public int Id { get; set; }

    [Required]
    [RegularExpression(@"^.+\S.*$", ErrorMessage = "Name cannot be empty or whitespace")]
    public string Name { get; set; } = string.Empty;

    public List<IngredientRecipe> IngredientRecipes { get; set; } = [];
}
