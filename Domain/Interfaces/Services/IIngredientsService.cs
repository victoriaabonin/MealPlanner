using Domain.Dtos;
using Domain.ResultPattern;

namespace Domain.Interfaces.Services;

public interface IIngredientsService
{
    Task<Result<List<IngredientDto>>> GetIngredientsAsync();

    Task<Result<IngredientDto>> AddIngredientAsync(IngredientDto ingredientDto);
 
    Task<Result<List<IngredientOfRecipeDto>>> GetIngredientsOfRecipesAggregatedAsync(int[] recipeIds);
}
