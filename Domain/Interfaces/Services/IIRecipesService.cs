using System;
using Domain.Dtos;

namespace Domain.Interfaces.Services;

public interface IRecipesService
{
    Task<RecipeDto> GetRecipesByIdAsync(int id);

    Task<List<RecipeDto>> GetRecipesAsync();

    Task<RecipeDto> AddRecipeAsync(RecipeDto recipeDto);

    Task<RecipeDto> AddIngredientAsync(AddIngredientToRecipeDto addIngredientToRecipeDto);
}
