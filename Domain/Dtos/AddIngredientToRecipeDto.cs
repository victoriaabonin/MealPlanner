namespace Domain.Dtos;

public class AddIngredientToRecipeDto
{
    public int RecipeId { get; set; }

    public int IngredientId { get; set; }
    
    public double Quantity { get; set; }
}
