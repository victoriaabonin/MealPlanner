using Domain.Exceptions.Database;
using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Infrastructure.Repositories;

public class RecipesRepository : IRecipesRepository
{
    private readonly MealPlannerDbContext mealPlannerDbContext;

    public RecipesRepository(MealPlannerDbContext mealPlannerDbContext)
    {
        this.mealPlannerDbContext = mealPlannerDbContext;
    }

    public async Task<Recipe> GetRecipeByIdAsync(int id, CancellationToken cancellationToken)
    {
        var recipe = await mealPlannerDbContext.Recipes
            .Include(x => x.RecipeIngredients)
                .ThenInclude(x => x.Ingredient)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (recipe is null)
        {
            throw new EntityNotFoundException();
        }

        return recipe;
    }

    public async Task<List<Recipe>> GetRecipesAsync(CancellationToken cancellationToken)
    {
        return await mealPlannerDbContext.Recipes.ToListAsync(cancellationToken);
    }

    public async Task<List<Recipe>> GetRecipesAsync(int[] ids, CancellationToken cancellationToken)
    {
        return await mealPlannerDbContext.Recipes
        .Include(x => x.RecipeIngredients)
            .ThenInclude(x => x.Ingredient)
        .Where(x => ids.Contains(x.Id))
        .ToListAsync(cancellationToken);
    }

    public async Task<Recipe> AddRecipeAsync(Recipe recipe, CancellationToken cancellationToken)
    {
        try
        {
            await mealPlannerDbContext.Recipes.AddAsync(recipe, cancellationToken);
            await mealPlannerDbContext.SaveChangesAsync(cancellationToken);
            return recipe;
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
}
