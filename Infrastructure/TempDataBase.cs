using Domain.Enums;
using Domain.Models;

namespace Infrastructure;

public static class TempDataBase
{
    public static List<Ingredient> Ingredients { get; set; }
    public static List<Recipe> Recipes { get; set; }
    public static List<IngredientRecipe> IngredientRecipes { get; set; }

    public static void InitDataBase()
    {
        Ingredients.Add(new Ingredient()
        {
            Id = 1,
            Name = "Rice",
        });

        Ingredients.Add(new Ingredient()
        {
            Id = 2,
            Name = "Beans",
        });

        Ingredients.Add(new Ingredient()
        {
            Id = 3,
            Name = "Lettuce",
        });

        Ingredients.Add(new Ingredient()
        {
            Id = 4,
            Name = "Tomato",
        });

        Ingredients.Add(new Ingredient()
        {
            Id = 5,
            Name = "Chicken",
        });

        Ingredients.Add(new Ingredient()
        {
            Id = 6,
            Name = "Arborio rice",
        });

        Ingredients.Add(new Ingredient()
        {
            Id = 7,
            Name = "Oyster mushroom",
        });

        Ingredients.Add(new Ingredient()
        {
            Id = 8,
            Name = "Leek",
        });

        Recipes.Add(new Recipe()
        {
            Id = 1,
            Name = "Rice and Beans with protein and salad",
        });

        Recipes.Add(new Recipe()
        {
            Id = 2,
            Name = "Leek risotto with oyster mushroom",
        });

        IngredientRecipes.Add(new IngredientRecipe()
        {
            IngredientId = 1,
            RecipeId = 1,
            UnitOfMeasurement = UnitOfMeasurement.Cups,
            Quantity = 0.5
        });

        IngredientRecipes.Add(new IngredientRecipe()
        {
            IngredientId = 2,
            RecipeId = 1,
            UnitOfMeasurement = UnitOfMeasurement.Cups,
            Quantity = 0.5
        });

        IngredientRecipes.Add(new IngredientRecipe()
        {
            IngredientId = 1,
            RecipeId = 3,
            UnitOfMeasurement = UnitOfMeasurement.ToTaste,
            Quantity = 1
        });

        IngredientRecipes.Add(new IngredientRecipe()
        {
            IngredientId = 1,
            RecipeId = 3,
            UnitOfMeasurement = UnitOfMeasurement.Unit,
            Quantity = 1
        });

        IngredientRecipes.Add(new IngredientRecipe()
        {
            IngredientId = 1,
            RecipeId = 5,
            UnitOfMeasurement = UnitOfMeasurement.Grams,
            Quantity = 200
        });

        IngredientRecipes.Add(new IngredientRecipe()
        {
            IngredientId = 6,
            RecipeId = 2,
            UnitOfMeasurement = UnitOfMeasurement.Cups,
            Quantity = 0.5
        });

        IngredientRecipes.Add(new IngredientRecipe()
        {
            IngredientId = 7,
            RecipeId = 2,
            UnitOfMeasurement = UnitOfMeasurement.Unit,
            Quantity = 0.5
        });

        IngredientRecipes.Add(new IngredientRecipe()
        {
            IngredientId = 8,
            RecipeId = 2,
            UnitOfMeasurement = UnitOfMeasurement.Grams,
            Quantity = 100
        });
    }
}
