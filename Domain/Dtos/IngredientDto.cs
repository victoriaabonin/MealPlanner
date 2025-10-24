namespace Domain.Dtos;

public class IngredientDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<RecipeDto> RecipesDtos { get; set; }
}
