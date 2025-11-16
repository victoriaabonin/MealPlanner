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

    public async Task<Result<RecipeDto>> UpdateRecipeAsync(RecipeDto recipeDto, CancellationToken cancellationToken)
    {
        try
        {
            if (recipeDto.Id == 0)
            {
                return Errors.MissingPropertyId;
            }

            var ingredient = new Recipe()
            {
                Id = recipeDto.Id,
                Name = recipeDto.Name
            };

            await recipesRepository.UpdateRecipeAsync(ingredient, cancellationToken);

            return recipeDto;
        }
        catch (EntityAlreadyExistsException)
        {
            return Errors.RecipeAlreadyExists;
        }
        catch (EntityNotFoundException)
        {
            return Errors.RecipeNotFound;
        }
    }

    public async Task<Result<RecipeDto>> RemoveIngredientFromRecipeAsync(int recipeId, int ingredientId, CancellationToken cancellationToken)
    {
        try
        {
            if (recipeId == 0 || ingredientId == 0)
            {
                return Errors.MissingPropertyId;
            }

            await recipeIngredientRepository.DeleteIngredientRecipeAsync(recipeId, ingredientId, cancellationToken);

            var recipe = await recipesRepository.GetRecipeByIdAsync(recipeId, cancellationToken);

            var recipeDto = RecipeMapper.MapToRecipeDto(recipe);

            return recipeDto;
        }
        catch (EntityNotFoundException)
        {
            return Errors.RecipeIngredientNotFound;
        }
    }

    public async Task<Result> DeleteRecipeAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            if (id == 0)
            {
                return Errors.MissingPropertyId;
            }

            await recipesRepository.DeleteRecipeAsync(id, cancellationToken);

            return Result.Success();
        }
        catch (EntityNotFoundException)
        {
            return Errors.RecipeNotFound;
        }
    }
}
