using Domain.Enums;
using Domain.Models;

namespace Infrastructure;

public class TempDataBase
{
    public static List<Ingredient> Ingredients { get; set; } = new List<Ingredient>()
    {
        new Ingredient()
        {
            Id = 1,
            Name = "Rice",
        },
        new Ingredient()
        {
            Id = 2,
            Name = "Beans",
        },
        new Ingredient()
        {
            Id = 3,
            Name = "Lettuce",
        },
        new Ingredient()
        {
            Id = 4,
            Name = "Tomato",
        },
        new Ingredient()
        {
            Id = 5,
            Name = "Chicken",
        },
        new Ingredient()
        {
            Id = 6,
            Name = "Arborio rice",
        },
        new Ingredient()
        {
            Id = 7,
            Name = "Oyster mushroom",
        },
        new Ingredient()
        {
            Id = 8,
            Name = "Leek",
        }
    };

    public static List<Recipe> Recipes { get; set; } = new List<Recipe>()
    {
        new Recipe()
        {
            Id = 1,
            Name = "Rice and Beans with protein and salad",
            IngredientRecipes = new List<IngredientRecipe>()
            {
                new IngredientRecipe()
                {
                    IngredientId = 1,
                    RecipeId = 1,
                    UnitOfMeasurement = UnitOfMeasurement.Cups,
                    Quantity = 0.5
                },
                new IngredientRecipe()
                {
                    IngredientId = 2,
                    RecipeId = 1,
                    UnitOfMeasurement = UnitOfMeasurement.Cups,
                    Quantity = 0.5
                },
                new IngredientRecipe()
                {
                    IngredientId = 3,
                    RecipeId = 1,
                    UnitOfMeasurement = UnitOfMeasurement.ToTaste,
                    Quantity = 1
                },
                new IngredientRecipe()
                {
                    IngredientId = 4,
                    RecipeId = 1,
                    UnitOfMeasurement = UnitOfMeasurement.Unit,
                    Quantity = 1
                },
                new IngredientRecipe()
                {
                    IngredientId = 5,
                    RecipeId = 1,
                    UnitOfMeasurement = UnitOfMeasurement.Grams,
                    Quantity = 200
                }
            }
        },
        new Recipe()
        {
            Id = 2,
            Name = "Leek risotto with oyster mushroom",
            IngredientRecipes = new List<IngredientRecipe>()
            {
                new IngredientRecipe()
                {
                    IngredientId = 6,
                    RecipeId = 2,
                    UnitOfMeasurement = UnitOfMeasurement.Cups,
                    Quantity = 0.5
                },
                new IngredientRecipe()
                {
                    IngredientId = 7,
                    RecipeId = 2,
                    UnitOfMeasurement = UnitOfMeasurement.Unit,
                    Quantity = 0.5
                },
                new IngredientRecipe()
                {
                    IngredientId = 8,
                    RecipeId = 2,
                    UnitOfMeasurement = UnitOfMeasurement.Grams,
                    Quantity = 100
                }
            }
        }
    };
}
