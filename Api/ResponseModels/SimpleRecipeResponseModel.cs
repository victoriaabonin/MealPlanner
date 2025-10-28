using System;

namespace Api.ResponseModels;

public class SimpleRecipeResponseModel
{
    public int Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
}
