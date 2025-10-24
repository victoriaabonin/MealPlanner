using Domain.Dtos;

namespace Domain.Interfaces.Services;

public interface IIngredientsService
{
    Task<List<IngredientDto>> GetIngredientsAsync();

    Task<IngredientDto> AddIngredient(IngredientDto ingredientDto);
}
