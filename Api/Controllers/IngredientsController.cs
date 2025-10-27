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

        public async Task<ActionResult<List<IngredientResponseModel>>> Get()
        {
            var ingredientsDtos = await ingredientsService.GetIngredientsAsync();

            var ingredientsResponseModels = ingredientsDtos.Select(ingredientDto => new IngredientResponseModel()
            {
                Id = ingredientDto.Id,
                Name = ingredientDto.Name,
                UnitOfMeasurement = ingredientDto.UnitOfMeasurement,
                RecipesResponseModels = ingredientDto.RecipesDtos.Select(recipeDto => new RecipeResponseModel()
                {
                    Id = recipeDto.Id,
                    Name = recipeDto.Name
                }).ToList()
            });

            return Ok(ingredientsResponseModels);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<IngredientResponseModel>> Add(IngredientRequestModel ingredientRequestModel)
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
