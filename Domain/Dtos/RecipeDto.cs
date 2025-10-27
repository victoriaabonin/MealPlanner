namespace Domain.Dtos;

public class RecipeDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<IngredientOfRecipeDto> IngredientsOfRecipesDtos { get; set; } = [];
}
