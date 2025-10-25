using Domain.Dtos;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;

namespace Presentation.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly IIngredientsService ingredientsService;

        public IngredientsController(IIngredientsService ingredientsService)
        {
            this.ingredientsService = ingredientsService;
        }

        public async Task<ActionResult> Index()
        {
            var ingredientsDtos = await ingredientsService.GetIngredientsAsync();

            var ingredientsViewModel = ingredientsDtos.Select(ingredientDto => new IngredientViewModel()
            {
                Id = ingredientDto.Id,
                Name = ingredientDto.Name,
                Recipes = ingredientDto.RecipesDtos?.Select(recipeDto => new RecipeViewModel()
                {
                    Id = recipeDto.Id,
                    Name = recipeDto.Name
                }).ToList()
            }).ToList();

            return View(ingredientsViewModel);
        }

        public async Task<ActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Add(IngredientViewModel ingredientViewModel)
        {
            var ingredientDto = new IngredientDto()
            {
                Name = ingredientViewModel.Name
            };

            await ingredientsService.AddIngredientAsync(ingredientDto);

            return RedirectToAction(nameof(Index));
        }
    }
}
