using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Recipe
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;

    public List<RecipeIngredient> RecipeIngredients { get; set; } = [];
}
