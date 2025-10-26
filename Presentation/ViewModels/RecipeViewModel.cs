using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels;

public class RecipeViewModel
{
    public int Id { get; set; }

    [RegularExpression(@"^.+\S.*$", ErrorMessage = "Code cannot be empty or whitespace")]
    public string Name { get; set; } = string.Empty;

    public List<IngredientOfRecipeViewModel> IngredientsOfRecipesViewModels { get; set; } = [];
}
