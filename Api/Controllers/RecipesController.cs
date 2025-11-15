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
        private readonly IIngredientsService ingredientsService;

        public RecipesController(IRecipesService recipesService, IIngredientsService ingredientsService)
        {
            this.recipesService = recipesService;
            this.ingredientsService = ingredientsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SimpleRecipeResponseModel>>> GetRecipesAsync(CancellationToken cancellationToken)
        {
            var result = await recipesService.GetRecipesAsync(cancellationToken);

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
        public async Task<ActionResult<RecipeResponseModel>> GetRecipeById(int id, CancellationToken cancellationToken)
        {
            var result = await recipesService.GetRecipesByIdAsync(id, cancellationToken);

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
        public async Task<ActionResult<List<RecipeResponseModel>>> AddRecipe(RecipeRequestModel requestModel, CancellationToken cancellationToken)
        {
            var recipeDto = new RecipeDto()
            {
                Name = requestModel.Name
            };

            var result = await recipesService.AddRecipeAsync(recipeDto, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error!.Description);
            }

            return Created();
        }

        [HttpPost]
        [Route("addIngredient")]
        public async Task<ActionResult<RecipeResponseModel>> AddIngredient(AddIngredientToRecipeRequestModel requestModel, CancellationToken cancellationToken)
        {
            var addIngredientToRecipeDto = new AddIngredientToRecipeDto()
            {
                IngredientId = requestModel.IngredientId,
                RecipeId = requestModel.RecipeId,
                Quantity = requestModel.Quantity
            };

            var result = await recipesService.AddIngredientAsync(addIngredientToRecipeDto, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error!.Description);
            }

            return Created();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRecipe(RecipeRequestModel recipeRequestModel, CancellationToken cancellationToken)
        {
            var recipeDto = new RecipeDto()
            {
                Id = recipeRequestModel.Id,
                Name = recipeRequestModel.Name
            };

            var result = await recipesService.UpdateRecipeAsync(recipeDto, cancellationToken);

            if (result.IsFailure)
            {
                return BadRequest(result.Error!.Description);
            }

            return NoContent();
        }

        [HttpGet]
        [Route("ingredients")]
        public async Task<ActionResult<List<IngredientOfRecipeResponseModel>>> GetIngredientsFromRecipes([FromQuery] int[] recipeIds, CancellationToken cancellationToken)
        {
            var result = await ingredientsService.GetIngredientsOfRecipesAggregatedAsync(recipeIds, cancellationToken);

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
    }
}
