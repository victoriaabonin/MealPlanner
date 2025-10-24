using Domain.Dtos;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Application.Services;

public class IngredientsService : IIngredientsService
{
    private readonly IIngredientsRepository ingredientsRepository;

    public IngredientsService(IIngredientsRepository ingredientsRepository)
    {
        this.ingredientsRepository = ingredientsRepository;
    }

    public async Task<List<IngredientDto>> GetIngredientsAsync()
    {
        var ingredients = await ingredientsRepository.GetIngredientsAsync();

        var ingredientDtos = ingredients.Select(ingredient => new IngredientDto()
        {
            Id = ingredient.Id,
            Name = ingredient.Name,
            RecipesDtos = ingredient.IngredientRecipes?.Select(ingredientRecipe => new RecipeDto()
            {
                Id = ingredientRecipe.RecipeId
            }).ToList()
        }).ToList();

        return ingredientDtos;
    }

    public async Task<IngredientDto> AddIngredient(IngredientDto ingredientDto)
    {
        var ingredient = new Ingredient()
        {
            Name = ingredientDto.Name
        };

        var savedIngredient = await ingredientsRepository.AddIngredient(ingredient);

        var savedIngredientDto = new IngredientDto()
        {
            Id = savedIngredient.Id,
            Name = savedIngredient.Name
        };

        return savedIngredientDto;
    }
}
