using Domain.Dtos;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Application.Services;

public class RecipesService : IRecipesService
{
    private readonly IRecipesRepository recipesRepository;

    public RecipesService(IRecipesRepository recipesRepository)
    {
        this.recipesRepository = recipesRepository;
    }

    public async Task<List<RecipeDto>> GetRecipeAsync()
    {
        var recipes = await recipesRepository.GetRecipesAsync();

        var recipesDtos = recipes.Select(recipe => new RecipeDto()
        {
            Id = recipe.Id,
            Name = recipe.Name,
            IngredientsOfRecipesDtos = recipe.IngredientRecipes.Select(ingredientRecipe => new IngredientOfRecipeDto()
            {
                IngredientDto = new IngredientDto()
                {
                    Id = ingredientRecipe.IngredientId,
                    Name = ingredientRecipe.Ingredient.Name,
                    UnitOfMeasurement = ingredientRecipe.Ingredient.UnitOfMeasurement
                },
                Quantity = ingredientRecipe.Quantity,
            }).ToList()
        }).ToList();

        return recipesDtos;
    }
}
