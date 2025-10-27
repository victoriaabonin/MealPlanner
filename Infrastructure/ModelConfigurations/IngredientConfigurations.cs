using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ModelConfigurations;

public class IngredientConfigurations : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
{
        builder.HasKey(ingredient => ingredient.Id);

        builder.HasIndex(ingredient => ingredient.Name)
            .IsUnique();

        builder.Property(ingredient => ingredient.Name)
            .IsRequired();
    }
}
