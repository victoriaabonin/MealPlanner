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
                        Name = ingredientOfRecipeDto.IngredientDto.Name,
                        UnitOfMeasurement = ingredientOfRecipeDto.IngredientDto.UnitOfMeasurement
                    },
                    Quantity = ingredientOfRecipeDto.Quantity
                }).ToList()
            }).ToList();

            return View(recipesViewModel);
        }

        public async Task<ActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(RecipeViewModel recipeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(recipeViewModel);
            }

            var recipeDto = new RecipeDto()
            {
                Name = recipeViewModel.Name,
                IngredientsOfRecipeDtos = recipeViewModel.IngredientsOfRecipesViewModels.Select(ingredientOfRecipeViewModel => new IngredientOfRecipeDto()
                {
                    IngredientDto = new IngredientDto()
                    {
                        Id = ingredientOfRecipeViewModel.IngredientViewModel.Id,
                        Name = ingredientOfRecipeViewModel.IngredientViewModel.Name,
                        UnitOfMeasurement = ingredientOfRecipeViewModel.IngredientViewModel.UnitOfMeasurement,
                    },
                    Quantity = ingredientOfRecipeViewModel.Quantity,
                }).ToList()
            };

            return View();
        }
    }
}
