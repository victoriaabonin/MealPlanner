using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipesService recipesService;

        public RecipesController(IRecipesService recipesService)
        {
            this.recipesService = recipesService;
        }

        public async Task<ActionResult> Index()
        {
            var recipesDtos = await recipesService.GetRecipeAsync();

            var recipesViewModel = recipesDtos.Select(recipeDto => new RecipeViewModel()
            {
                Id = recipeDto.Id,
                Name = recipeDto.Name,
                IngredientsOfRecipesViewModels = recipeDto.IngredientsOfRecipeDtos.Select(ingredientOfRecipeDto => new IngredientOfRecipeViewModel()
                {
                    IngredientViewModel = new IngredientViewModel()
                    {
                        Id = ingredientOfRecipeDto.IngredientDto.Id,
                        Name = ingredientOfRecipeDto.IngredientDto.Name
                    },
                    Quantity = ingredientOfRecipeDto.Quantity,
                    UnitOfMeasurement = ingredientOfRecipeDto.UnitOfMeasurement
                }).ToList()
            }).ToList();

            return View(recipesViewModel);
        }

    }
}
