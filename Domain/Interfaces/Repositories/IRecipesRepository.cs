using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IRecipesRepository
{
    Task<Recipe> GetRecipeByIdAsync(int id);

    Task<List<Recipe>> GetRecipesAsync();

    Task<List<Recipe>> GetRecipesAsync(int[] ids);
    
    Task<Recipe> AddRecipeAsync(Recipe recipe);
}
