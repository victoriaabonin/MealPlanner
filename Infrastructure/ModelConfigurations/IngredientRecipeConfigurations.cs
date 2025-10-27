using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ModelConfigurations;

public class IngredientRecipeConfigurations : IEntityTypeConfiguration<IngredientRecipe>
{
    public void Configure(EntityTypeBuilder<IngredientRecipe> builder)
    {
        builder.HasKey(ur => new { ur.RecipeId, ur.IngredientId });
    }
}
