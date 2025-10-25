using System;
using Domain.Interfaces.Repositories;
using Domain.Models;

namespace Infrastructure.Repositories;

public class RecipesRepository : IRecipesRepository
{
    public async Task<List<Recipe>> GetRecipesAsync()
    {
        return TempDataBase.Recipes;
    }
}
