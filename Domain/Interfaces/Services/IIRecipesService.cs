using System;
using Domain.Dtos;
using Domain.ResultPattern;

namespace Domain.Interfaces.Services;

public interface IRecipesService
{
    Task<Result<RecipeDto>> GetRecipesByIdAsync(int id);

    Task<Result<List<RecipeDto>>> GetRecipesAsync();

    Task<Result<RecipeDto>> AddRecipeAsync(RecipeDto recipeDto);

    Task<Result<RecipeDto>> AddIngredientAsync(AddIngredientToRecipeDto addIngredientToRecipeDto);
}
