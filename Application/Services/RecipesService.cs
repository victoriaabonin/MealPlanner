using Application.Mappers;
using Domain.Dtos;
using Domain.Exceptions.Database;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.ResultPattern;

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

    public async Task<Result<RecipeDto>> GetRecipesByIdAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            var recipe = await recipesRepository.GetRecipeByIdAsync(id, cancellationToken);

            var recipeDto = RecipeMapper.MapToRecipeDto(recipe);

            return recipeDto;
        }
        catch (EntityNotFoundException)
        {
            return Errors.RecipeNotFound;
        }
    }

    public async Task<Result<List<RecipeDto>>> GetRecipesAsync(CancellationToken cancellationToken)
    {
        var recipes = await recipesRepository.GetRecipesAsync(cancellationToken);

        var recipesDtos = recipes.Select(recipe => RecipeMapper.MapToRecipeDto(recipe)).ToList();

        return recipesDtos;
    }

    public async Task<Result<RecipeDto>> AddRecipeAsync(RecipeDto recipeDto, CancellationToken cancellationToken)
    {
        try
        {
            var recipe = new Recipe()
            {
                Name = recipeDto.Name
            };

            await recipesRepository.AddRecipeAsync(recipe, cancellationToken);

            recipeDto.Id = recipe.Id;

            return recipeDto;
        }
        catch (EntityAlreadyExistsException)
        {
            return Errors.RecipeAlreadyExists;
        }
    }

    public async Task<Result<RecipeDto>> AddIngredientAsync(AddIngredientToRecipeDto addIngredientToRecipeDto, CancellationToken cancellationToken)
    {
        try
        {
            var recipeIngredient = new RecipeIngredient()
            {
                IngredientId = addIngredientToRecipeDto.IngredientId,
                RecipeId = addIngredientToRecipeDto.RecipeId,
                Quantity = addIngredientToRecipeDto.Quantity
            };

            await recipeIngredientRepository.AddIngredientRecipeAsync(recipeIngredient, cancellationToken);

            var recipe = await recipesRepository.GetRecipeByIdAsync(addIngredientToRecipeDto.RecipeId, cancellationToken);

            var recipeDto = RecipeMapper.MapToRecipeDto(recipe);

            return recipeDto;
        }
        catch (EntityAlreadyExistsException)
        {
            return Errors.RecipeIngredientAlreadyExists;
        }
    }
}
