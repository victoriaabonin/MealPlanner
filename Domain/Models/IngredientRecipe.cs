using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class IngredientRecipe
{
    [Required]
    public int IngredientId { get; set; }

    public Ingredient? Ingredient { get; set; }

    [Required]
    public int RecipeId { get; set; }

    public Recipe? Recipe { get; set; }

    public double Quantity { get; set; }
}
