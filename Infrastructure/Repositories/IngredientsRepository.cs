using Domain.Interfaces.Repositories;
using Domain.Models;

namespace Infrastructure.Repositories;

public class IngredientsRepository : IIngredientsRepository
{
    public async Task<List<Ingredient>> GetIngredientsAsync()
    {
        return TempDataBase.Ingredients;
    }
}
