using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class MealPlannerDbContext : DbContext
{
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<IngredientRecipe> IngredientRecipes { get; set; }

    public MealPlannerDbContext(DbContextOptions<MealPlannerDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<IngredientRecipe>()
        .HasKey(ur => new { ur.RecipeId, ur.IngredientId });
}
}
