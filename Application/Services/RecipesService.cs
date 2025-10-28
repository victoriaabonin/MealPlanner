using Domain.Dtos;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Application.Services;

public class RecipesService : IRecipesService
{
    private readonly IRecipesRepository recipesRepository;
    private readonly IRecipeIngredientRepository recipeIngredientRepository;

    public RecipesService(IRecipesRepository recipesRepository, IRecipeIngredientRepository recipeIngredientRepository)
    {
        this.recipesRepository = recipesRepository;
        this.recipeIngredientRepository = recipeIngredientRepository;
    }

    public async Task<RecipeDto> GetRecipesByIdAsync(int id)
    {
        var recipe = await recipesRepository.GetRecipeByIdAsync(id);

        var recipeDto = new RecipeDto()
        {
            Id = recipe.Id,
            Name = recipe.Name,
            Ingredients = recipe.RecipeIngredients.Select(x => new IngredientOfRecipeDto()
            {
                Id = x.Ingredient.Id,
                Name = x.Ingredient.Name,
                UnitOfMeasurement = x.Ingredient.UnitOfMeasurement,
                Quantity = x.Quantity
            }).ToList()
        };

        return recipeDto;
    }

    public async Task<List<RecipeDto>> GetRecipesAsync()
    {
        var recipes = await recipesRepository.GetRecipesAsync();

        var recipesDtos = recipes.Select(recipe => new RecipeDto()
        {
            Id = recipe.Id,
            Name = recipe.Name,
            Ingredients = recipe.RecipeIngredients.Select(x => new IngredientOfRecipeDto()
            {
                Id = x.Ingredient.Id,
                Name = x.Ingredient.Name,
                UnitOfMeasurement = x.Ingredient.UnitOfMeasurement,
                Quantity = x.Quantity,
            }).ToList()
        }).ToList();

        return recipesDtos;
    }

    public async Task<RecipeDto> AddRecipeAsync(RecipeDto recipeDto)
    {
        var recipe = new Recipe()
        {
            Name = recipeDto.Name
        };

        await recipesRepository.AddRecipeAsync(recipe);

        recipeDto.Id = recipe.Id;

        return recipeDto;
    }

    public async Task<RecipeDto> AddIngredientAsync(AddIngredientToRecipeDto addIngredientToRecipeDto)
    {
        var recipeIngredient = new RecipeIngredient()
        {
            IngredientId = addIngredientToRecipeDto.IngredientId,
            RecipeId = addIngredientToRecipeDto.RecipeId,
            Quantity = addIngredientToRecipeDto.Quantity
        };

        await recipeIngredientRepository.AddIngredientRecipeAsync(recipeIngredient);

        var recipe = await recipesRepository.GetRecipeByIdAsync(addIngredientToRecipeDto.RecipeId);

        var recipeDto = new RecipeDto()
        {
            Id = recipe.Id,
            Name = recipe.Name,
            Ingredients = recipe.RecipeIngredients.Select(x => new IngredientOfRecipeDto()
            {
                Id = x.Ingredient.Id,
                Name = x.Ingredient.Name,
                UnitOfMeasurement = x.Ingredient.UnitOfMeasurement,
                Quantity = x.Quantity,
            }).ToList()
        };

        return recipeDto;
    }
}
