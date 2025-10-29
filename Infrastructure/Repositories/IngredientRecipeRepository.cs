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

    public async Task<RecipeIngredient> AddIngredientRecipeAsync(RecipeIngredient recipeIngredient)
    {
        await mealPlannerDbContext.RecipeIngredient.AddAsync(recipeIngredient);
        
        await mealPlannerDbContext.SaveChangesAsync();

        return recipeIngredient;
    }
}
