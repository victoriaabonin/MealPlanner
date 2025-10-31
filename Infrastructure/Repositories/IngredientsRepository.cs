using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

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
        try
        {
            await mealPlannerDbContext.Ingredients.AddAsync(ingredient);
            await mealPlannerDbContext.SaveChangesAsync();
            return ingredient;
        }
        catch (DbUpdateException exception) when (exception.InnerException is PostgresException postgresException)
        {
            if (postgresException.SqlState == "23505")
            {
                throw new EntityAlreadyExistsException("An ingredient with this name is already registered");
            }

            throw postgresException;
        }
    }
}
