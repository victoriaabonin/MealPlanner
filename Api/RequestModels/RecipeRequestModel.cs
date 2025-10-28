using System.ComponentModel.DataAnnotations;

namespace Api.RequestModels;

public class RecipeRequestModel
{
    [Required]
    public string Name { get; set; } = string.Empty;
}
