using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IRecipeIngredientRepository
{
    Task<RecipeIngredient> AddIngredientRecipeAsync(RecipeIngredient ingredientRecipe);
}
