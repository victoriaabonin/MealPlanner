using System;
using Domain.Dtos;

namespace Domain.Interfaces.Services;

public interface IRecipesService
{
    Task<List<RecipeDto>> GetRecipeAsync();
}
