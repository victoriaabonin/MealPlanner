using Domain.Dtos;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Application.Services;

public class IngredientsService : IIngredientsService
{
    private readonly IIngredientsRepository ingredientsRepository;

    private readonly IRecipesRepository recipesRepository;

    public IngredientsService(IIngredientsRepository ingredientsRepository, IRecipesRepository recipesRepository)
    {
        this.ingredientsRepository = ingredientsRepository;
        this.recipesRepository = recipesRepository;
    }

    public async Task<List<IngredientDto>> GetIngredientsAsync()
    {
        var ingredients = await ingredientsRepository.GetIngredientsAsync();

        var ingredientDtos = ingredients.Select(ingredient => new IngredientDto()
        {
            Id = ingredient.Id,
            Name = ingredient.Name,
            UnitOfMeasurement = ingredient.UnitOfMeasurement,
            RecipesDtos = ingredient.RecipeIngredients.Select(ingredientRecipe => new RecipeDto()
            {
                Name = ingredientRecipe.Recipe.Name,
                Id = ingredientRecipe.RecipeId
            }).ToList()
        }).ToList();

        return ingredientDtos;
    }

    public async Task<IngredientDto> AddIngredientAsync(IngredientDto ingredientDto)
    {
        var ingredient = new Ingredient()
        {
            Name = ingredientDto.Name,
            UnitOfMeasurement = ingredientDto.UnitOfMeasurement
        };

        await ingredientsRepository.AddIngredientAsync(ingredient);

        ingredientDto.Id = ingredient.Id;

        return ingredientDto;
    }

    public async Task<List<IngredientOfRecipeDto>> GetIngredientsOfRecipesAggregatedAsync(int[] recipeIds)
    {
        var recipes = await recipesRepository.GetRecipesAsync(recipeIds);

        var IngredientsOfRecipesAggregated = recipes
        .SelectMany(x => x.RecipeIngredients)
        .GroupBy(x => x.Ingredient)
        .Select(x => new IngredientOfRecipeDto()
        {
            Id = x.First().Ingredient.Id,
            Name = x.First().Ingredient.Name,
            UnitOfMeasurement = x.First().Ingredient.UnitOfMeasurement,
            Quantity = x.Sum(x => x.Quantity)
        }).ToList();

        return IngredientsOfRecipesAggregated;
    }
}
