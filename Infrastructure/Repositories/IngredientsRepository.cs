using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class IngredientsRepository : IIngredientsRepository
{
    private readonly MealPlannerDbContext mealPlannerDbContext;

    public IngredientsRepository(MealPlannerDbContext mealPlannerDbContext)
    {
        this.mealPlannerDbContext = mealPlannerDbContext;
    }

    public async Task<List<Ingredient>> GetIngredientsAsync()
    {
        return await mealPlannerDbContext.Ingredients.ToListAsync();
    }

    public async Task<Ingredient> AddIngredientAsync(Ingredient ingredient)
    {
        await mealPlannerDbContext.Ingredients.AddAsync(ingredient);
        await mealPlannerDbContext.SaveChangesAsync();
        return ingredient;
    }
}
