namespace Domain.ResultPattern;


public record Error(ErrorType Type, string Description);


public static class Errors
{
    public static Error RecipeAlreadyExists { get; } = new(ErrorType.EntityAlreadyExists, "A recipe with this name is already registered");
    public static Error IngredientAlreadyExists { get; } = new(ErrorType.EntityAlreadyExists, "An ingredient with this name is already registered");
    public static Error RecipeIngredientAlreadyExists { get; } = new(ErrorType.EntityAlreadyExists, "The recipe already has the given ingredient");
    public static Error RecipeNotFound { get; } = new(ErrorType.EntityNotFound, "A recipe with the given query was not found");
    public static Error IngredientNotFound { get; } = new(ErrorType.EntityNotFound, "An Ingredient with the given query was not found");
    public static Error RecipeIngredientNotFound { get; } = new(ErrorType.EntityNotFound, "An Ingredient in the given recipe was not found");
    public static Error MissingPropertyId { get; } = new(ErrorType.RequiredPropertyMissing, "The property Id is missing");
    public static Error IngredientHasLinkedRecipes { get; } = new(ErrorType.EntityHasExistingRelation, "The ingredient cannot be deleted because it is used in one or more recipes");
}

public enum ErrorType
{
    EntityAlreadyExists,
    EntityNotFound,
    RequiredPropertyMissing,
    EntityHasExistingRelation
}
