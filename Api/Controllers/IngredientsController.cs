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
            var result = await ingredientsService.GetIngredientsAsync();

            if (result.IsFailure)
            {
                return BadRequest(result.Error!.Description);
            }

            var ingredientsDtos = result.Value!;

            var ingredientsResponseModels = ingredientsDtos.Select(x => new IngredientResponseModel()
            {
                Id = x.Id,
                Name = x.Name,
                UnitOfMeasurement = x.UnitOfMeasurement
            });

            return Ok(ingredientsResponseModels);
        }

        [HttpGet]
        [Route("fromRecipes")]
        public async Task<ActionResult<List<IngredientOfRecipeResponseModel>>> GetIngredientsFromRecipes([FromQuery] int[] recipeIds)
        {
            var result = await ingredientsService.GetIngredientsOfRecipesAggregatedAsync(recipeIds);

            if (result.IsFailure)
            {
                return BadRequest(result.Error!.Description);
            }

            var ingredientRecipeDtos = result.Value!;

            var aggregatedIngredients = ingredientRecipeDtos.Select(x => new IngredientOfRecipeResponseModel()
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

            if (result.IsFailure)
            {
                return BadRequest(result.Error!.Description);
            }

            ingredientDto = result.Value!;

            var ingredientResponseModel = new IngredientResponseModel()
            {
                Id = ingredientDto.Id,
                Name = ingredientDto.Name,
                UnitOfMeasurement = ingredientDto.UnitOfMeasurement
            };

            return Ok(ingredientResponseModel);
        }
    }
}
