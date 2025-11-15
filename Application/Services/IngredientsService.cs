using Domain.Dtos;
using Domain.Exceptions.Database;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using Domain.ResultPattern;

namespace Application.Services;

public class IngredientsService : IIngredientsService
{
    private readonly IIngredientsRepository ingredientsRepository;
    private readonly IRecipesRepository recipesRepository;

    public IngredientsService(
        IIngredientsRepository ingredientsRepository,
        IRecipesRepository recipesRepository
        )
    {
        this.ingredientsRepository = ingredientsRepository;
        this.recipesRepository = recipesRepository;
    }

    public async Task<Result<List<IngredientDto>>> GetIngredientsAsync(CancellationToken cancellationToken)
    {
        var ingredients = await ingredientsRepository.GetIngredientsAsync(cancellationToken);

        var ingredientDtos = ingredients.Select(ingredient => new IngredientDto()
        {
            Id = ingredient.Id,
            Name = ingredient.Name,
            UnitOfMeasurement = ingredient.UnitOfMeasurement,
            RecipesDtos = ingredient.RecipeIngredients.Select(ingredientRecipe => new RecipeDto()
            {
                Name = ingredientRecipe.Recipe!.Name,
                Id = ingredientRecipe.Recipe!.Id
            }).ToList()
        }).ToList();

        return ingredientDtos;
    }

    public async Task<Result<IngredientDto>> AddIngredientAsync(IngredientDto ingredientDto, CancellationToken cancellationToken)
    {
        try
        {
            var ingredient = new Ingredient()
            {
                Name = ingredientDto.Name,
                UnitOfMeasurement = ingredientDto.UnitOfMeasurement
            };

            await ingredientsRepository.AddIngredientAsync(ingredient, cancellationToken);

            ingredientDto.Id = ingredient.Id;

            return ingredientDto;
        }
        catch (EntityAlreadyExistsException)
        {
            return Errors.IngredientAlreadyExists;
        }
    }

    public async Task<Result<List<IngredientOfRecipeDto>>> GetIngredientsOfRecipesAggregatedAsync(int[] recipeIds, CancellationToken cancellationToken)
    {
        var recipes = await recipesRepository.GetRecipesAsync(recipeIds, cancellationToken);

        var IngredientsOfRecipesAggregated = recipes
        .SelectMany(x => x.RecipeIngredients)
        .GroupBy(x => x.Ingredient)
        .Select(x => new IngredientOfRecipeDto()
        {
            Id = x.First().Ingredient!.Id,
            Name = x.First().Ingredient!.Name,
            UnitOfMeasurement = x.First().Ingredient!.UnitOfMeasurement,
            Quantity = x.Sum(x => x.Quantity)
        }).ToList();

        return IngredientsOfRecipesAggregated;
    }

    public async Task<Result<IngredientDto>> UpdateIngredientAsync(IngredientDto ingredientDto, CancellationToken cancellationToken)
    {
        try
        {
            if (ingredientDto.Id == 0)
            {
                return Errors.MissingPropertyId;
            }

            var ingredient = new Ingredient()
            {
                Id = ingredientDto.Id,
                Name = ingredientDto.Name,
                UnitOfMeasurement = ingredientDto.UnitOfMeasurement
            };

            await ingredientsRepository.UpdateIngredientAsync(ingredient, cancellationToken);

            return ingredientDto;
        }
        catch (EntityAlreadyExistsException)
        {
            return Errors.IngredientAlreadyExists;
        }
        catch (EntityNotFoundException)
        {
            return Errors.IngredientNotFound;
        }
    }

    public async Task<Result<IngredientDto>> GetIngredientByIdAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            var ingredient = await ingredientsRepository.GetIngredientByIdAsync(id, cancellationToken);

            var ingredientDto = new IngredientDto()
            {
                Id = ingredient.Id,
                Name = ingredient.Name,
                UnitOfMeasurement = ingredient.UnitOfMeasurement
            };

            return ingredientDto;
        }
        catch (EntityNotFoundException)
        {
            return Errors.IngredientNotFound;
        }
    }
}