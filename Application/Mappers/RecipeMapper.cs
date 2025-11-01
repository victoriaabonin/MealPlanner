using System;
using Domain.Dtos;
using Domain.Models;

namespace Application.Mappers;

public static class RecipeMapper
{
    public static RecipeDto MapToRecipeDto(Recipe recipe)
    {
        return new RecipeDto()
        {
            Id = recipe.Id,
            Name = recipe.Name,
            Ingredients = recipe.RecipeIngredients.Select(x => new IngredientOfRecipeDto()
            {
                Id = x.Ingredient!.Id,
                Name = x.Ingredient!.Name,
                UnitOfMeasurement = x.Ingredient!.UnitOfMeasurement,
                Quantity = x.Quantity
            }).ToList()
        };
    }
}
