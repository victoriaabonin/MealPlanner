using Domain.Dtos;

namespace Domain.Interfaces.Services;

public interface IIngredientsService
{
    Task<List<IngredientDto>> GetIngredientsAsync();
}
