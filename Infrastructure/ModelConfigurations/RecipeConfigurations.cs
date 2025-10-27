using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.ModelConfigurations;

public class RecipeConfigurations: IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
{
        builder.HasKey(recipe => recipe.Id);

        builder.HasIndex(recipe => recipe.Name)
            .IsUnique();

        builder.Property(recipe => recipe.Name)
            .IsRequired();
    }
}
