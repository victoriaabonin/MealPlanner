using System.ComponentModel.DataAnnotations;

namespace Api.RequestModels;

public class RecipeRequestModel
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; } = string.Empty;
}
