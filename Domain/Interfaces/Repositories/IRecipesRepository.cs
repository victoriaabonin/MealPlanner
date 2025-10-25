using System;
using Domain.Models;

namespace Domain.Interfaces.Repositories;

public interface IRecipesRepository
{
    Task<List<Recipe>> GetRecipesAsync();
}
