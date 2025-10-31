using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

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
        try
        {
            await mealPlannerDbContext.RecipeIngredient.AddAsync(recipeIngredient);
            await mealPlannerDbContext.SaveChangesAsync();
            return recipeIngredient;
        }
        catch (DbUpdateException exception) when (exception.InnerException is PostgresException postgresException)
        {
            if (postgresException.SqlState == "23505")
            {
                throw new EntityAlreadyExistsException("The ingredient for this recipe is already registered");
            }

            throw postgresException;
        }
    }
}
