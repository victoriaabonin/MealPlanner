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

    public async Task<Ingredient> UpdateIngredientAsync(Ingredient ingredient, CancellationToken cancellationToken)
    {
        try
        {
            var existingIngredient = await mealPlannerDbContext.Ingredients.FirstOrDefaultAsync(x => x.Id == ingredient.Id, cancellationToken);

            if (existingIngredient is null)
            {
                throw new EntityNotFoundException();
            }

            existingIngredient.Name = ingredient.Name;
            existingIngredient.UnitOfMeasurement = ingredient.UnitOfMeasurement;

            mealPlannerDbContext.Ingredients.Update(ingredient);
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
