using Domain.Dtos;
using Domain.ResultPattern;

namespace Domain.Interfaces.Services;

public interface IRecipesService
{
    Task<Result<RecipeDto>> GetRecipesByIdAsync(int id, CancellationToken cancellationToken);

    Task<Result<List<RecipeDto>>> GetRecipesAsync(CancellationToken cancellationToken);

    Task<Result<RecipeDto>> AddRecipeAsync(RecipeDto recipeDto, CancellationToken cancellationToken);

    Task<Result<RecipeDto>> AddIngredientAsync(AddIngredientToRecipeDto addIngredientToRecipeDto, CancellationToken cancellationToken);

    Task<Result<RecipeDto>> UpdateRecipeAsync(RecipeDto recipeDto, CancellationToken cancellationToken);
}
