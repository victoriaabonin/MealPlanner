using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels;

public class IngredientViewModel
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
    
    public List<RecipeViewModel> Recipes { get; set; }
}
