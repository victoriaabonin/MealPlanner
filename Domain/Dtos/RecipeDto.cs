namespace Domain.Dtos;

public class RecipeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<IngredientOfRecipeDto> IngredientsOfRecipeDtos { get; set; }
}
