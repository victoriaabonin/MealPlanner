using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IIngredientsRepository
{
    Task<List<Ingredient>> GetIngredientsAsync();

    Task<Ingredient> AddIngredient(Ingredient ingredient);
}
