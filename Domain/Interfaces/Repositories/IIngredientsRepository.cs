using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IIngredientsRepository
{
    Task<List<Ingredient>> GetIngredientsAsync(CancellationToken cancellationToken);

    Task<Ingredient> AddIngredientAsync(Ingredient ingredient, CancellationToken cancellationToken);
    
    Task<Ingredient> UpdateIngredientAsync(Ingredient ingredient, CancellationToken cancellationToken);
}
