using Api.RequestModels;
using Api.ResponseModels;
using Domain.Dtos;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipesService recipesService;

        public RecipesController(IRecipesService recipesService)
        {
            this.recipesService = recipesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SimpleRecipeResponseModel>>> GetRecipesAsync()
        {
            var result = await recipesService.GetRecipesAsync();

            if (result.IsFailure)
            {
                return BadRequest(result.Error!.Description);
            }

            var recipeDto = result.Value!;

            var recipesResponseModel = recipeDto.Select(x => new SimpleRecipeResponseModel()
            {
                Id = x.Id,
                Name = x.Name
            });

            return Ok(recipesResponseModel);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<RecipeResponseModel>> GetRecipeById(int id)
        {
            var result = await recipesService.GetRecipesByIdAsync(id);

            if (result.IsFailure)
            {
                return BadRequest(result.Error!.Description);
            }

            var recipeDto = result.Value!;

            var recipeResponseModel = new RecipeResponseModel()
            {
                Id = recipeDto.Id,
                Name = recipeDto.Name,
                Ingredients = recipeDto.Ingredients.Select(x => new IngredientOfRecipeResponseModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    UnitOfMeasurement = x.UnitOfMeasurement,
                    Quantity = x.Quantity
                }).ToList()
            };

            return Ok(recipeResponseModel);
        }

        [HttpPost]
        public async Task<ActionResult<List<RecipeResponseModel>>> AddRecipe(RecipeRequestModel requestModel)
        {
            var recipeDto = new RecipeDto()
            {
                Name = requestModel.Name
            };

            var result = await recipesService.AddRecipeAsync(recipeDto);

            if (result.IsFailure)
            {
                return BadRequest(result.Error!.Description);
            }

            return Created();
        }

        [HttpPost]
        [Route("addIngredient")]
        public async Task<ActionResult<RecipeResponseModel>> AddIngredient(AddIngredientToRecipeRequestModel requestModel)
        {
            var addIngredientToRecipeDto = new AddIngredientToRecipeDto()
            {
                IngredientId = requestModel.IngredientId,
                RecipeId = requestModel.RecipeId,
                Quantity = requestModel.Quantity
            };

            var result = await recipesService.AddIngredientAsync(addIngredientToRecipeDto);

            if (result.IsFailure)
            {
                return BadRequest(result.Error!.Description);
            }

            return Created();
        }
    }
}
