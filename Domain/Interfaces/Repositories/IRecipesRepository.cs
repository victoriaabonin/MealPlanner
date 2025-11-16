using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IRecipesRepository
{
    Task<Recipe> GetRecipeByIdAsync(int id, CancellationToken cancellationToken);

    Task<List<Recipe>> GetRecipesAsync(CancellationToken cancellationToken);

    Task<List<Recipe>> GetRecipesAsync(int[] ids, CancellationToken cancellationToken);

    Task<Recipe> AddRecipeAsync(Recipe recipe, CancellationToken cancellationToken);
    
    Task<Recipe> UpdateRecipeAsync(Recipe recipe, CancellationToken cancellationToken);

    Task DeleteRecipeAsync(int id, CancellationToken cancellationToken);
}
