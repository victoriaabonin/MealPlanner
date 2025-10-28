using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Models;

public class Ingredient
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public UnitOfMeasurement UnitOfMeasurement { get; set; }

    public List<RecipeIngredient> RecipeIngredients { get; set; } = [];
}
