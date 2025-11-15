using Domain.Exceptions.Database;
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

    public async Task<RecipeIngredient> AddIngredientRecipeAsync(RecipeIngredient recipeIngredient, CancellationToken cancellationToken)
    {
        try
        {
            await mealPlannerDbContext.RecipeIngredient.AddAsync(recipeIngredient, cancellationToken);
            await mealPlannerDbContext.SaveChangesAsync(cancellationToken);
            return recipeIngredient;
        }
        catch (DbUpdateException exception) when (exception.InnerException is PostgresException postgresException)
        {
            if (postgresException.SqlState == "23505")
            {
                throw new EntityAlreadyExistsException();
            }

            throw postgresException;
        }
    }

    public async Task DeleteIngredientRecipeAsync(int recipeId, int ingredientId, CancellationToken cancellationToken)
    {
        var recipeIngredient = await mealPlannerDbContext.RecipeIngredient.FirstOrDefaultAsync(x => x.IngredientId == ingredientId && x.RecipeId == recipeId, cancellationToken);

        if (recipeIngredient is null)
        {
            throw new EntityNotFoundException();
        }

        mealPlannerDbContext.RecipeIngredient.Remove(recipeIngredient);
        await mealPlannerDbContext.SaveChangesAsync(cancellationToken);
    }
}
