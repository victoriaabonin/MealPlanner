using Domain.Interfaces.Repositories;
using Domain.Models;

namespace Infrastructure.Repositories;

public class IngredientsRepository : IIngredientsRepository
{
    public async Task<List<Ingredient>> GetIngredientsAsync()
    {
        return TempDataBase.Ingredients;
    }

    public async Task<Ingredient> AddIngredient(Ingredient ingredient)
    {
        var ingredientsQuantity = TempDataBase.Ingredients.Count;

        ingredient.Id = ingredientsQuantity++;

        TempDataBase.Ingredients.Add(ingredient);

        return ingredient;
    }
}
