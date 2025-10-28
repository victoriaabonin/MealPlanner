using Api.RequestModels;
using Api.ResponseModels;
using Domain.Dtos;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientsService ingredientsService;

        public IngredientsController(IIngredientsService ingredientsService)
        {
            this.ingredientsService = ingredientsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<IngredientResponseModel>>> GetIngredients()
        {
            var ingredientsDtos = await ingredientsService.GetIngredientsAsync();

            var ingredientsResponseModels = ingredientsDtos.Select(x => new IngredientResponseModel()
            {
                Id = x.Id,
                Name = x.Name,
                UnitOfMeasurement = x.UnitOfMeasurement
            });

            return Ok(ingredientsResponseModels);
        }

        [HttpGet]
        public async Task<ActionResult<List<IngredientOfRecipeResponseModel>>> GetIngredientsFromListOfRecipes(int[] recipeIds)
        {
            var result = await ingredientsService.GetIngredientsOfRecipesAggregatedAsync(recipeIds);

            var aggregatedIngredients = result.Select(x => new IngredientOfRecipeResponseModel()
            {
                Id = x.Id,
                Name = x.Name,
                UnitOfMeasurement = x.UnitOfMeasurement,
                Quantity = x.Quantity
            }).ToList();

            return Ok(aggregatedIngredients);
        }

        [HttpPost]
        public async Task<ActionResult<IngredientResponseModel>> AddIngredient(IngredientRequestModel ingredientRequestModel)
        {
            var ingredientDto = new IngredientDto()
            {
                Name = ingredientRequestModel.Name,
                UnitOfMeasurement = ingredientRequestModel.UnitOfMeasurement
            };

            var result = await ingredientsService.AddIngredientAsync(ingredientDto);

            var ingredientResponseModel = new IngredientResponseModel()
            {
                Id = result.Id,
                Name = result.Name,
                UnitOfMeasurement = result.UnitOfMeasurement
            };

            return Ok(ingredientResponseModel);
        }
    }
}
