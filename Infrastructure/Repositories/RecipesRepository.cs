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

    public async Task<List<Recipe>> GetRecipesAsync()
    {
        return await mealPlannerDbContext.Recipes.ToListAsync();
    }

    public async Task<Recipe> AddRecipesAsync(Recipe recipe)
    {
        await mealPlannerDbContext.Recipes.AddAsync(recipe);
        await mealPlannerDbContext.SaveChangesAsync();
        return recipe;
    }
}
