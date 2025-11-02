using Domain.Exceptions.Database;
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

    public async Task<List<Ingredient>> GetIngredientsAsync(CancellationToken cancellationToken)
    {
        return await mealPlannerDbContext.Ingredients.ToListAsync(cancellationToken);
    }

    public async Task<Ingredient> AddIngredientAsync(Ingredient ingredient, CancellationToken cancellationToken)
    {
        try
        {
            await mealPlannerDbContext.Ingredients.AddAsync(ingredient, cancellationToken);
            await mealPlannerDbContext.SaveChangesAsync(cancellationToken);
            return ingredient;
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
