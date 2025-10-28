using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RecipesRepository : IRecipesRepository
{
    private readonly MealPlannerDbContext mealPlannerDbContext;

    public RecipesRepository(MealPlannerDbContext mealPlannerDbContext)
    {
        this.mealPlannerDbContext = mealPlannerDbContext;
    }

    public async Task<Recipe> GetRecipeByIdAsync(int id)
    {
        return await mealPlannerDbContext.Recipes
            .Include(x => x.RecipeIngredients)
                .ThenInclude(x => x.Ingredient)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Recipe>> GetRecipesAsync()
    {
        return await mealPlannerDbContext.Recipes.ToListAsync();
    }

    public async Task<List<Recipe>> GetRecipesAsync(int[] ids)
    {
        return await mealPlannerDbContext.Recipes.Where(x => ids.Contains(x.Id)).ToListAsync();
    }

    public async Task<Recipe> AddRecipeAsync(Recipe recipe)
    {
        await mealPlannerDbContext.Recipes.AddAsync(recipe);
        await mealPlannerDbContext.SaveChangesAsync();
        return recipe;
    }
}
