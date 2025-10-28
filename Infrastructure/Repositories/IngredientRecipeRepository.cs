using Domain.Interfaces.Repositories;
using Domain.Models;

namespace Infrastructure.Repositories;

public class IngredientRecipesRepository : IRecipeIngredientRepository
{
    private readonly MealPlannerDbContext mealPlannerDbContext;

    public IngredientRecipesRepository(MealPlannerDbContext mealPlannerDbContext)
    {
        this.mealPlannerDbContext = mealPlannerDbContext;
    }

    public async Task<RecipeIngredient> AddIngredientRecipeAsync(RecipeIngredient ingredientRecipe)
    {
        await mealPlannerDbContext.IngredientRecipes.AddAsync(ingredientRecipe);

        return ingredientRecipe;
    }
}
