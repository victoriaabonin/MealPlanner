using Domain.Dtos;
using Domain.ResultPattern;

namespace Domain.Interfaces.Services;

public interface IIngredientsService
{
    Task<Result<List<IngredientDto>>> GetIngredientsAsync(CancellationToken cancellationToken);

    Task<Result<IngredientDto>> AddIngredientAsync(IngredientDto ingredientDto, CancellationToken cancellationToken);
    
    Task<Result<IngredientDto>> UpdateIngredientAsync(IngredientDto ingredientDto, CancellationToken cancellationToken);
 
    Task<Result<List<IngredientOfRecipeDto>>> GetIngredientsOfRecipesAggregatedAsync(int[] recipeIds, CancellationToken cancellationToken);
}
