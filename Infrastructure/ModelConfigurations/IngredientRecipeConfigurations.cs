using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ModelConfigurations;

public class IngredientRecipeConfigurations : IEntityTypeConfiguration<RecipeIngredient>
{
    public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
    {
        builder.HasKey(x => new { x.RecipeId, x.IngredientId });

        builder.Property(x => x.Quantity)
            .IsRequired();
    }
}
